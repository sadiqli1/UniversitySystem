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

namespace UniversitySystem.Application.Features.Queries.SpecializationQueries
{
    public class SpecializationGetQueryHandler : IRequestHandler<SpecializationGetQuery, SpecializationItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SpecializationGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<SpecializationItemDto> Handle(SpecializationGetQuery request, CancellationToken cancellationToken)
        {
            Specialization existed = await _unit.SpecializationRepository.GetByIdAsync(request.Id, "Sector", "Section", "Faculty");
            SpecializationItemDto dto = _mapper.Map<SpecializationItemDto>(existed);
            return dto;
        }
    }
}
