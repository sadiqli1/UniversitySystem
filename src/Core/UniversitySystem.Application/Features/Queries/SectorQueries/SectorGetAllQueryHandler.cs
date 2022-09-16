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
    public class SectorGetAllQueryHandler : IRequestHandler<SectorGetAllQuery, List<SectorGetItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<SectorGetItemDto>> Handle(SectorGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(null);
            List<SectorGetItemDto> dtos = _mapper.Map<List<SectorGetItemDto>>(sectors);
            return dtos;
        }
    }
}