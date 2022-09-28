using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Attendance;
using UniversitySystem.Application.Features.Commands.AttendanceCommands;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AttendancesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AttendanceCreateCommand command)
        {
            int value = await _mediator.Send(command);
            switch (value)
            {
                case 0:
                    return BadRequest(new
                    {
                        code = "relation",
                        description = "this student does not belong in this lesson"
                    });
                    break;
                case -1:
                    return BadRequest(new
                    {
                        code = "relation",
                        description = "this lesson is not available at the time you specified"
                    });
                    break;
                case -2:
                    return BadRequest(new
                    {
                        code = "date",
                        description = "this lesson has not been conducted yet"
                    });
                    break;
                case -3:
                    return BadRequest(new
                    {
                        code = "again",
                        description = "this data can be generated once"
                    });
                    break;
                default:
                    break;
            }

            return StatusCode(StatusCodes.Status201Created, value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AttendanceUpdateItemDto dto)
        {
            AttendanceUpdateCommand command = _mapper.Map<AttendanceUpdateCommand>(dto);
            command.Id = id;
            int value = await _mediator.Send(command);
            if(value == 0) return NotFound();
            return Ok(value);
        }
    }
}