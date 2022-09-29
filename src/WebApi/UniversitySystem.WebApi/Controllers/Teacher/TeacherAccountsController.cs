using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Commands.TeacherAccountCommand;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers.Teacher
{
    [Route("tech/[controller]")]
    [ApiController]
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
        [HttpGet("data")]
        [Authorize]
        public async Task<IActionResult> Data()
        {
            Person person = await _usermanager.FindByNameAsync("190120006");
            return Ok(person);
        }
    }
}