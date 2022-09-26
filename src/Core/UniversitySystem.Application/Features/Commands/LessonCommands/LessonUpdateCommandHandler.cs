using AutoMapper;
using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.LessonCommands
{
    public class LessonUpdateCommandHandler : IRequestHandler<LessonUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonUpdateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(LessonUpdateCommand request, CancellationToken cancellationToken)
        {
            Lesson existed = await _unit.LessonRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;

            Course course = await _unit.CourseRepository.GetByIdAsync(request.CourseId);
            Group group = await _unit.GroupRepository.GetByIdAsync(request.GroupId);
            Teacher teacher = await _unit.TeacherRepository.GetByIdAsync(request.TeacherId);
            if (course == null || group == null || teacher == null) throw new RelationException() { Code = "relation", Description = "there is no such relation" };

            await _unit.LessonRepository.UpdateAsync(existed);
            Lesson lesson = _mapper.Map<Lesson>(request);
            await _unit.SaveChangesAsync();
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