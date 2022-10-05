using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.Features.Commands.SectionCommands;
using UniversitySystem.Application.Features.Queries.SectionQueries;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("edu/[controller]")]
    [ApiController]
    [Authorize(Roles = "EducationDepartment, Admin")]
    public class SectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new SectionGetAllQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SectionGetQuery section = new SectionGetQuery(id);
            SectionItemDto dto = await _mediator.Send(section);
            if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectionPostDto dto)
        {
            SectionCreateCommand command = new SectionCreateCommand() { Name = dto.Name, Code = dto.Code };
            SectionCreateCommand value = await _mediator.Send(command);
            if(value == null) return BadRequest();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SectionPostDto dto)
        {
            SectionUpdateCommand command = new SectionUpdateCommand(){ Id = id, Name = dto.Name, Code = dto.Code };
            int value = await _mediator.Send(command);
            if(value == 0) return BadRequest();
            return StatusCode(StatusCodes.Status200OK, value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            SectionDeleteCommand command = new SectionDeleteCommand(id);
            int value = await _mediator.Send(command);if(value == 0) return NotFound();
            if(value == -1) return BadRequest(new
            {
                code = "relation",
                description = "related to some information"
            });
            return StatusCode(StatusCodes.Status200OK, value);
        }
    }
}