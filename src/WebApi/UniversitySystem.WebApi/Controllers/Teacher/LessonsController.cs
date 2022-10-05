using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.Features.Commands.LessonCommands;
using UniversitySystem.Application.Features.Queries.LessonQueries;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("tech/[controller]")]
    [ApiController]
    [Authorize(Roles = "Tytor, Admin")]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LessonsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            LessonItemDto dto = await _mediator.Send(new LessonGetQuery(id));
            if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<LessonItemDto> dtos = await _mediator.Send(new LessonGetAllQuery());
            if(dtos == null) return NotFound();
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonPostDto dto)
        {
            LessonCreateCommand command = _mapper.Map<LessonCreateCommand>(dto);
            return StatusCode(StatusCodes.Status201Created, await _mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LessonPostDto dto)
        {
            LessonUpdateCommand command = _mapper.Map<LessonUpdateCommand>(dto); 
            command.Id = id;
            int value = await _mediator.Send(command);
            if (value == 0) return NotFound();
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            LessonDeleteCommand command = new LessonDeleteCommand(id);
            int value = await _mediator.Send(command);
            if(value == 0) return NotFound();
            return NoContent();
        }
        [HttpGet("Days")]
        public async Task<IActionResult> GetDays()
        {
            return Ok(await _mediator.Send(new DayGetQuery()));
        }
    }
}