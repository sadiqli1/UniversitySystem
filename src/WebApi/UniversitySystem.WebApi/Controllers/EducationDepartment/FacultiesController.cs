using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.Features.Commands.FacultyCommands;
using UniversitySystem.Application.Features.Queries.FacultyQueries;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("edu/[controller]")]
    [ApiController]
    [Authorize(Roles = "EducationDepartment, Admin")]
    public class FacultiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacultiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            FacultyItemDto dto = await _mediator.Send(new FacultyGetQuery(id)); if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<FacultyItemDto> dtos = await _mediator.Send(new FacultyGetAllQuery()); if(dtos == null) return NotFound();
            return Ok(dtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FacultyCreateCommand command)
        {
            int value = await _mediator.Send(command); if(value == 0) return BadRequest();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, FacultyPostDto dto)
        {
            FacultyUpdateCommand command = new FacultyUpdateCommand(id, dto.Name);
            int value = await _mediator.Send(command); if(value == 0) return BadRequest();
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int value = await _mediator.Send(new FacultyDeleteCommand(id)); 
            if(value == 0) return NotFound();
            if(value == -1) return BadRequest(new
            {
                code = "relation",
                description = "related to some information"
            });
            return Ok(value);
        }
    }
}