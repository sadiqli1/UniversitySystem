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
    public class SectionUpdateCommandHandler : IRequestHandler<SectionUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionUpdateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SectionUpdateCommand request, CancellationToken cancellationToken)
        {
            Section existed = await _unit.SectionRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            foreach (var item in sections)
            {
                if (item.Name == request.Name && existed.Name != request.Name || item.Code == request.Code && existed.Code != request.Code) return 0;
            }
            await _unit.SectionRepository.UpdateAsync(existed);
            existed.Name = request.Name;
            existed.Code = request.Code;
            await _unit.SaveChangesAsync();
            return request.Id;
        }
    }
}
