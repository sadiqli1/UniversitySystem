using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SpecializationCommand
{
    public class SpecializationCreateCommandHandler : IRequestHandler<SpecializationCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SpecializationCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SpecializationCreateCommand request, CancellationToken cancellationToken)
        {
            List<Specialization> existed = await _unit.SpecializationRepository
                .GetAllAsync(s => s.Name.Trim().ToLower() == request.Name.Trim().ToLower() || s.Code == request.Code);
            if (existed.Count != 0) return 0;
            Specialization specialization = _mapper.Map<Specialization>(request);
            specialization.CreateAt = DateTime.Now;
            await _unit.SpecializationRepository.AddAsync(specialization);
            return specialization.Id;
        }
    }
}
