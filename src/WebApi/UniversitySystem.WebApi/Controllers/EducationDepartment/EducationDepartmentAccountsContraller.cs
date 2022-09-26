using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Commands.TeacherAccountCommand;

namespace UniversitySystem.WebApi.Controllers.EducationDepartment
{
    [Route("edu/[controller]")]
    [ApiController]
    public class EducationDepartmentAccountsContraller : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationDepartmentAccountsContraller(IMediator mediator)
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