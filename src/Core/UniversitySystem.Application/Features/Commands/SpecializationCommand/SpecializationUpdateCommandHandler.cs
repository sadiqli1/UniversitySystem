using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SpecializationCommand
{
    public class SpecializationUpdateCommandHandler : IRequestHandler<SpecializationUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SpecializationUpdateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SpecializationUpdateCommand request, CancellationToken cancellationToken)
        {
            Specialization existed = await _unit.SpecializationRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            List<Specialization> specializations = await _unit.SpecializationRepository.GetAllAsync(s => s.Name == request.Name || s.Code == request.Code);
            if(specializations.Count != 0) return 0;
            await _unit.SpecializationRepository.UpdateAsync(existed);
            Specialization specialization = _mapper.Map<Specialization>(request);
            await _unit.SaveChangesAsync();
            return specialization.Id;
        }
    }
}
