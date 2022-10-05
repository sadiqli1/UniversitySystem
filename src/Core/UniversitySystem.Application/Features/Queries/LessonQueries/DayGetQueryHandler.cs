using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.LessonQueries
{
    public class DayGetQueryHandler : IRequestHandler<DayGetQuery, List<DaysGetDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DayGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<DaysGetDto>> Handle(DayGetQuery request, CancellationToken cancellationToken)
        {
            List<DayHour> dayHours = await _unit.DayHourRepository.GetAllAsync(null, "Day", "Hour");
            List<DaysGetDto> dtos = _mapper.Map<List<DaysGetDto>>(dayHours);
            return dtos;
        }
    }
}