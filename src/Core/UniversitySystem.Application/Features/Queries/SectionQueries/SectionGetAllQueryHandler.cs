using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.SectionQueries
{
    public class SectionGetAllQueryHandler : IRequestHandler<SectionGetAllQuery, List<SectionItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<SectionItemDto>> Handle(SectionGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            List<SectionItemDto> dtos = _mapper.Map<List<SectionItemDto>>(sections);
            return dtos;
        }
    }
}