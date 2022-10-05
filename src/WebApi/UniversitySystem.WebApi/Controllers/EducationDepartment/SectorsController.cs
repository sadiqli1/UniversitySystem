using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Features.Commands.SectorCommands;
using UniversitySystem.Application.Features.Queries.SectorQueries;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("edu/[controller]")]
    [ApiController]
    [Authorize(Roles = "EducationDepartment, Admin")]
    public class SectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new SectorGetAllQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SectorGetItemDto dto = await _mediator.Send(new SectorGetQuery(id));
            if (dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectorPostDto dto)
        {
            SectorCreateCommand command = new SectorCreateCommand() { Name = dto.Name};
            int value = await _mediator.Send(command);
            if (value == 0) return BadRequest();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SectorPostDto dto)
        {
            SectorUpdateCommand command = new SectorUpdateCommand(id, dto.Name);
            int value = await _mediator.Send(command);
            if(value == 0) return BadRequest();
            return StatusCode(StatusCodes.Status200OK, value);
        }
        [HttpDelete]    
        public async Task<IActionResult> Delete(int id)
        {
            SectorDeleteCommand sector = new SectorDeleteCommand(id);
            int value = await _mediator.Send(sector);
            if(value == 0) return BadRequest();
            if (value == -1) return BadRequest(new
            {
                code = "relation",
                description = "related to some information"
            });
            return StatusCode(StatusCodes.Status200OK, value);
        }
    }
}