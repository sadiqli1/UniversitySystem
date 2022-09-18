using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.FacultyQueries
{
    public class FacultyGetAllQueryHandler : IRequestHandler<FacultyGetAllQuery, List<FacultyItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacultyGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<FacultyItemDto>> Handle(FacultyGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Faculty> existed = await _unit.FacultyRepository.GetAllAsync(null);
            List<FacultyItemDto> dtos = _mapper.Map<List<FacultyItemDto>>(existed);
            return dtos;
        }
    }
}