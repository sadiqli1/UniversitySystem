using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Point;
using UniversitySystem.Application.Features.Commands.PointListCommand;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PointListsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("sdf1/{id}")]
        public async Task<IActionResult> SDF1Create(int id, PointPostDto dto)
        {
            SDF1CreateCommand command = new SDF1CreateCommand() { Id = id, Point = dto.Point};
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("sdf2/{id}")]
        public async Task<IActionResult> SDF2Create(int id, PointPostDto dto)
        {
            SDF2CreateCommand command = new SDF2CreateCommand() { Id = id, Point = dto.Point };
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return StatusCode(StatusCodes.Status201Created, value);
        }
    }
}