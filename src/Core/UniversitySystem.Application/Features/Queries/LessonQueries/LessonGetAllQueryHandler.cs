using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.LessonQueries
{
    public class LessonGetAllQueryHandler : IRequestHandler<LessonGetAllQuery, List<LessonItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<LessonItemDto>> Handle(LessonGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Lesson> lessons = await _unit.LessonRepository.GetAllAsync(null, "Group", "Course", "Teacher", "Teacher.Person", "LessonDayHours", "LessonDayHours.DayHour", "LessonDayHours.DayHour.Day", "LessonDayHours.DayHour.Hour", "LessonSchedules");
            if (lessons == null) return null;
            List<LessonItemDto> dtos = _mapper.Map<List<LessonItemDto>>(lessons);
            return dtos;
        }
    }
}
