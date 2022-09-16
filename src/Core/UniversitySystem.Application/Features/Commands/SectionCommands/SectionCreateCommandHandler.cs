﻿using System;
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
    public class SectionCreateCommandHandler : IRequestHandler<SectionCreateCommand, SectionCreateCommand>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectionCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<SectionCreateCommand> Handle(SectionCreateCommand request, CancellationToken cancellationToken)
        {
            List<Section> sections = await _unit.SectionRepository.GetAllAsync(null);
            foreach (var item in sections)
            {
                if (item.Name == request.Name || item.Code == request.Code) return null;
            }
            Section section = _mapper.Map<Section>(request);
            await _unit.SectionRepository.AddAsync(section);
            return request;
        }
    }
}
