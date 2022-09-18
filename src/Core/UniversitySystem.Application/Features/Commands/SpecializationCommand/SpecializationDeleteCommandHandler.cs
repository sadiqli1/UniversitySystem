using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SpecializationCommand
{
    public class SpecializationDeleteCommandHandler : IRequestHandler<SpecializationDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public SpecializationDeleteCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(SpecializationDeleteCommand request, CancellationToken cancellationToken)
        {
            Specialization existed = await _unit.SpecializationRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            await _unit.SpecializationRepository.DeleteAsync(existed);
            return request.Id;
        }
    }
}
