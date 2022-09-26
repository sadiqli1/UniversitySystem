using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Group;
using UniversitySystem.Application.Features.Commands.GroupCommands;
using UniversitySystem.Application.Features.Queries.GroupQueries;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GroupGetAllQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GroupItemDto dto = await _mediator.Send(new GroupGetQuery(id));
            if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupPostDto dto)
        {
            GroupCreateCommand command = new GroupCreateCommand() { Name = dto.Name, CourseId = dto.CourseId, SpecializationId = dto.SpecializationId, TeacherId = dto.TeacherId};
            int value = await _mediator.Send(command);
            if (value == 0) return BadRequest();
            if(value == -1) return BadRequest(new { code="relation", description= "no such relationship exists" });
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupPostDto dto)
        {
            GroupUpdateCommand command = new GroupUpdateCommand(id) { Name = dto.Name, CourseId = dto.CourseId, SpecializationId = dto.SpecializationId, TeacherId = dto.TeacherId };
            int value = await _mediator.Send(command);
            if(value == 0) return BadRequest();
            if (value == -1) return BadRequest(new { code = "relation", description = "no such relationship exists" });
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int value = await _mediator.Send(new GroupDeleteCommand(id));
            if (value == 0) return NotFound();
            if (value == -1) return BadRequest(new
            {
                code = "relation",
                description = "related to some information"
            });
            return Ok(value);
        }
    }
}
