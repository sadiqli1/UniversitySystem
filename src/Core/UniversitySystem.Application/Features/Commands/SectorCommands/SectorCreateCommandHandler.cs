using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(null);
            foreach (var item in sectors)
            {
                if (item.Name == request.Name) return 0;
            }
            Sector sector = _mapper.Map<Sector>(request);
            await _unit.SectorRepository.AddAsync(sector);
            return sector.Id;
        }
    }
}
