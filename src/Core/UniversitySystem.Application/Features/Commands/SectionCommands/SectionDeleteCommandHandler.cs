using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SectionCommands
{
    public class SectionDeleteCommandHandler : IRequestHandler<SectionDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionDeleteCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SectionDeleteCommand request, CancellationToken cancellationToken)
        {
            Section existed = await _unit.SectionRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            await _unit.SectionRepository.DeleteAsync(existed);
            return request.Id;
        }
    }
}
