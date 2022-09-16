using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using System.Linq;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Features.Queries.SpecializationQueries;
using MediatR;
using UniversitySystem.Application.Features.Commands.SpecializationCommand;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SpecializationsController(IUnitOfWork unit, IMapper mapper, IMediator mediator)
        {
            _unit = unit;
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SpecializationGetQuery query = new SpecializationGetQuery(id);
            SpecializationItemDto dto = await _mediator.Send(query); if(dto == null) return NotFound();
            return StatusCode(StatusCodes.Status200OK, dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, await _mediator.Send(new SpecializationGetAllQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationPostDto dto)
        {
            SpecializationCreateCommand command = new SpecializationCreateCommand() { Name = dto.Name, Code = dto.Code, Duration = dto.Duration, FacultyId = dto.FacultyId, SectionId = dto.SectionId, SectorId = dto.SectorId };
            var a = await _mediator.Send(command);
            if (a == 0) return BadRequest();
            return StatusCode(StatusCodes.Status201Created, a);
        }
    }
}
