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
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
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
            var value = await _mediator.Send(command);
            if (value == 0) return BadRequest();
            return StatusCode(StatusCodes.Status201Created, value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, SpecializationPostDto dto)
        {
            SpecializationUpdateCommand command = new SpecializationUpdateCommand(id) { Name = dto.Name, Code = dto.Code, Duration = dto.Duration, FacultyId = dto.FacultyId, SectionId = dto.SectionId, SectorId = dto.SectorId};
            int value = await _mediator.Send(command);
            if(value == 0) return BadRequest();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int value = await _mediator.Send(new SpecializationDeleteCommand(id));
            if(value == 0) return NotFound();
            return Ok(value);
        }
    }
}
