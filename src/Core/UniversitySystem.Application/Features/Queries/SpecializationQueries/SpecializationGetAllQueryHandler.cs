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
    public class SpecializationGetAllQueryHandler : IRequestHandler<SpecializationGetAllQuery, List<SpecializationItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SpecializationGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<SpecializationItemDto>> Handle(SpecializationGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Specialization> specializations = await _unit.SpecializationRepository.GetAllAsync(null, "Sector", "Section", "Faculty");
            List<SpecializationItemDto> dtos = _mapper.Map<List<SpecializationItemDto>>(specializations);
            return dtos;
        }
    }
}
