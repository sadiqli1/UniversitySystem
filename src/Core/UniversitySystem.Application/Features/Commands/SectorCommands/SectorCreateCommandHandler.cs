using System;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorCreateCommandHandler : IRequestHandler<SectorCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SectorCreateCommand request, CancellationToken cancellationToken)
        {
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(s => s.Name.Trim().ToLower() == request.Name.Trim().ToLower());
            if (sectors.Count != 0) return 0;
            Sector sector = _mapper.Map<Sector>(request);
            await _unit.SectorRepository.AddAsync(sector);
            return sector.Id;
        }
    }
}