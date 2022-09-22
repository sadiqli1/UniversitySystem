using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Commands.TeacherAccountCommand;

namespace UniversitySystem.WebApi.Controllers.Student
{
    [Route("stu/[controller]")]
    [ApiController]
    public class StudentAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            string token = await _mediator.Send(command);
            if (token == null) return BadRequest();
            return Ok(token);
        }
    }
}