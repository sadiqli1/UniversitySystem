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

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorUpdateCommandHandler : IRequestHandler<SectorUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorUpdateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SectorUpdateCommand request, CancellationToken cancellationToken)
        {
            Sector existed = await _unit.SectorRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            List<Sector> sectors = await _unit.SectorRepository.GetAllAsync(s => s.Name == request.Name && existed.Name != request.Name);
            if (sectors.Count != 0) return 0;
            await _unit.SectorRepository.UpdateAsync(existed);
            existed.Name = request.Name;
            await _unit.SaveChangesAsync();
            return request.Id;
        }
    }
}
