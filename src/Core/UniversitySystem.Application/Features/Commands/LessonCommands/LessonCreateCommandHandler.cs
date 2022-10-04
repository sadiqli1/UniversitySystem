using System.Globalization;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.LessonCommands
{
    public class LessonCreateCommandHandler : IRequestHandler<LessonCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(LessonCreateCommand request, CancellationToken cancellationToken)
        {
            Course course = await _unit.CourseRepository.GetByIdAsync(request.CourseId);
            Group group = await _unit.GroupRepository.GetByIdAsync(request.GroupId, "Students");
            Teacher teacher = await _unit.TeacherRepository.GetByIdAsync(request.TeacherId);
            List<DayHour> dayHours = await _unit.DayHourRepository.GetAllAsync(d => request.DayHourIds.Any(r => r == d.Id));

            if (course == null || group == null || teacher == null || dayHours.Count != request.DayHourIds.Count) throw new BadRequestException() { Code = "relation", Description = "there is no such relation" };

            Lesson lesson = _mapper.Map<Lesson>(request);

            await _unit.LessonRepository.AddAsync(lesson);

            await CreateDayHour(request.DayHourIds, lesson.Id);

            await CreateLessonSchedule(lesson.Id);

            if(group.Students.Count != 0)
            {
                foreach (Student st in group.Students)
                {
                    PointList pointList = new PointList()
                    {
                        StudentId = st.Id,
                        LessonId = lesson.Id
                    };
                    await _unit.PointListRepository.AddAsync(pointList);
                }
            }

            return lesson.Id;
        }

        public async Task CreateDayHour(List<int> Ids, int lessonId)
        {
            Lesson lesson = await _unit.LessonRepository.GetByIdAsync(lessonId);

            foreach (var dayHour in Ids)
            {
                LessonDayHour lessonDayHour = new LessonDayHour()
                {
                    LessonId = lesson.Id,
                    DayHourId = dayHour
                };
                await _unit.LessonDayHourRepository.AddAsync(lessonDayHour);
            }
        }

        public async Task CreateLessonSchedule(int lessonId)
        {
            Lesson lesson = await _unit.LessonRepository.GetByIdAsync(lessonId, "LessonDayHours", "LessonDayHours.DayHour", "LessonDayHours.DayHour.Day", "LessonDayHours.DayHour.Hour");

            CultureInfo ci = new CultureInfo("en-US");

            List<int> birincisemmonths = new List<int>() { 9, 10, 11, 12 };
            List<int> ikincisemmonths = new List<int>() { 2, 3, 4, 5 };

            List<string> vs = new List<string>();

            foreach (var l in lesson.LessonDayHours)
            {
                if (lesson.Course.Semester == 1)
                {
                    vs.AddRange(PrintSundays(DateTime.Now.Year, birincisemmonths, l.DayHour.Day.Name, l.DayHour.Hour.Name));
                }
                else
                {
                    vs.AddRange(PrintSundays(DateTime.Now.Year, ikincisemmonths, l.DayHour.Day.Name, l.DayHour.Hour.Name));
                }
            }

            foreach (var l in vs)
            {
                LessonSchedule schedule = new LessonSchedule()
                {
                    Date = Convert.ToDateTime(l),
                    LessonId = lesson.Id
                };
                await _unit.LessonScheduleRepository.AddAsync(schedule);
            }
            await _unit.LessonRepository.UpdateAsync(lesson);
            lesson.LessonHour = lesson.LessonSchedules.Count();
            await _unit.SaveChangesAsync();
        }

        protected static List<string> PrintSundays(int year, List<int> months, string dayName, string hour)
        {
            CultureInfo ci = new CultureInfo("en-US");
            List<string> days = new List<string>();
            foreach (int month in months)
            {
                for (int i = 1; i <= ci.Calendar.GetDaysInMonth(year, month); i++)
                {
                    if (new DateTime(year, month, i).DayOfWeek.ToString() == dayName)
                    {
                        days.Add($"{month}/{i}/{year} {hour}");
                    }
                }
            }
            return days;
        }
    }
}