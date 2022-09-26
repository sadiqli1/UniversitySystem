using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.LessonQueries
{
    public class LessonGetQueryHandler : IRequestHandler<LessonGetQuery, LessonItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<LessonItemDto> Handle(LessonGetQuery request, CancellationToken cancellationToken)
        {
            Lesson existed = await _unit.LessonRepository.GetByIdAsync(request.Id, "Group", "Course", "Teacher", "Teacher.Person");
            if (existed == null) return null;
            LessonItemDto dto = _mapper.Map<LessonItemDto>(existed);
            return dto;
        }
    }
}
