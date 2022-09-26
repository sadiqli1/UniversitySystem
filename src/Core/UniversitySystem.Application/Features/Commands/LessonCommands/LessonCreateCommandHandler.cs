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
            Group group = await _unit.GroupRepository.GetByIdAsync(request.GroupId);
            Teacher teacher = await _unit.TeacherRepository.GetByIdAsync(request.TeacherId);
            if (course == null || group == null || teacher == null) throw new RelationException() { Code = "relation", Description = "there is no such relation" };
            Lesson lesson = _mapper.Map<Lesson>(request);
            await _unit.LessonRepository.AddAsync(lesson);
            request.DayHourIds.ForEach(async dayHour =>
            {
                LessonDayHour lessonDayHour = new LessonDayHour()
                {
                    LessonId = lesson.Id,
                    DayHourId = dayHour
                };
                await _unit.LessonDayHourRepository.AddAsync(lessonDayHour);
            });
            return lesson.Id;
        }
    }
}