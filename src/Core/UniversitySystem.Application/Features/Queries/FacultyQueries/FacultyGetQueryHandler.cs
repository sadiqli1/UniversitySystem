using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.FacultyQueries
{
    public class FacultyGetQueryHandler : IRequestHandler<FacultyGetQuery, FacultyItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacultyGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<FacultyItemDto> Handle(FacultyGetQuery request, CancellationToken cancellationToken)
        {
            Faculty existed = await _unit.FacultyRepository.GetByIdAsync(request.Id);
            FacultyItemDto dto = _mapper.Map<FacultyItemDto>(existed);
            return dto;
        }
    }
}
