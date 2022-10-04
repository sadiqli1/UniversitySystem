using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.SectorQueries
{
    public class SectorGetQueryHandler : IRequestHandler<SectorGetQuery, SectorGetItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<SectorGetItemDto> Handle(SectorGetQuery request, CancellationToken cancellationToken)
        {
            Sector sector = await _unit.SectorRepository.GetByIdAsync(request.Id);
            SectorGetItemDto dto = _mapper.Map<SectorGetItemDto>(sector);
            return dto;
        }
    }
}