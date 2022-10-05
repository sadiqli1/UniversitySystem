using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Commands.UserAccountCommand;
using UniversitySystem.Application.Features.Queries.TeacherQueries;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers.Teacher
{
    [Route("tech/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher, Admin")]
    public class TeacherAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<Person> _usermanager;

        public TeacherAccountsController(IMediator mediator, UserManager<Person> userManager)
        {
            _mediator = mediator;
            _usermanager = userManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]UserLoginCommand command)
        {
            string token = await _mediator.Send(command);
            if (token == null) return BadRequest();
            return Ok(token);
        }
        [HttpGet("home")]
        public async Task<IActionResult> Home([FromQuery] TeacherGetQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("lesson")]
        public async Task<IActionResult> LessonGet([FromQuery]LessonGetQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}