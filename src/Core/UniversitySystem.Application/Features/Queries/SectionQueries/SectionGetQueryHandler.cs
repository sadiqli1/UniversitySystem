using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.SectionQueries
{
    public class SectionGetQueryHandler : IRequestHandler<SectionGetQuery, SectionItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<SectionItemDto> Handle(SectionGetQuery request, CancellationToken cancellationToken)
        {
            Section existed = await _unit.SectionRepository.GetByIdAsync(request.Id);
            SectionItemDto dto = _mapper.Map<SectionItemDto>(existed);
            return dto;
        }
    }
}
