using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceCreateCommandHandler : IRequestHandler<AttendanceCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _usermanager;

        public AttendanceCreateCommandHandler(IUnitOfWork unit, IMapper mapper, UserManager<Person> userManager)
        {
            _unit = unit;
            _mapper = mapper;
            _usermanager = userManager;
        }
        public async Task<int> Handle(AttendanceCreateCommand request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.TeacherUsername);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };

            Teacher teacher = await _unit.TeacherRepository.GetByExpression(t => t.PersonId == person.Id && t.Lessons.Any(x => x.Id == request.LessonId));
            if (teacher == null) throw new BadRequestException() { Code = "relation", Description = "this teacher does not teach this class" };

            List<Attendance> attendances = await _unit.AttendanceRepository
                .GetAllAsync(a => a.StudentId == request.StudentId && a.LessonScheduleId == request.LessonScheduleId && a.LessonId == request.LessonId);
            if(attendances.Count != 0) return -3;

            LessonSchedule schedule = await _unit.LessonScheduleRepository.GetByIdAsync(request.LessonScheduleId);
            Lesson lesson = await _unit.LessonRepository.GetByIdAsync(request.LessonId);
            Student student = await _unit.StudentRepository.GetByIdAsync(request.StudentId);
            LessonSchedule lessonSchedule = await _unit.LessonScheduleRepository.GetByIdAsync(request.LessonScheduleId);

            if (schedule == null || lesson == null || student == null) throw new BadRequestException(){ Code = "relation", Description = "there is no such relation"};

            if (lessonSchedule.LessonId != request.LessonId) return -1;

            if(lessonSchedule.Date > DateTime.Now) return -2;

            if (student.GroupId != lesson.GroupId) return 0;

            Attendance attendance = _mapper.Map<Attendance>(request);
            await _unit.AttendanceRepository.AddAsync(attendance);

            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == attendance.StudentId && p.LessonId == attendance.LessonId, "Lesson");
            List<Attendance> attendances1 = await _unit.AttendanceRepository.GetAllAsync(a => a.StudentId == pointList.StudentId && a.LessonId == pointList.LessonId);
            int count = default(int);
            foreach (var item in attendances1)
            {
                if (item.Status == false)
                {
                    count++;
                }
            }
            await _unit.PointListRepository.UpdateAsync(pointList);
            pointList.AttendanceCount = Convert.ToByte(count);
            pointList.AttendancePoint = Convert.ToByte(100 - ((count * 100) / pointList.Lesson.LessonHour));
            if (pointList.AttendancePoint < 75)
            {
                pointList.Failed = true;
            }
            else
            {
                pointList.Failed = false;
            }
            await _unit.SaveChangesAsync();

            return attendance.Id;
        }
    }
}