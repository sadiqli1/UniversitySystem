using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.Features.Commands.UserAccountCommand;
using UniversitySystem.Application.Features.Queries.StudentQueries;

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
        [HttpGet("home")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> Home([FromQuery]StudentGetQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("grades")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> GetGrades([FromQuery]StudentGradesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("ejurnal")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> EJurnal([FromQuery]StudentEJurnalQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("ejurnaldetail")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> EJurnalDetail([FromQuery] StudentEJurnalDetailQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("course_schedule")]
        [Authorize(Roles = "Student, Admin")]
        public async Task<IActionResult> CourseSchedule([FromQuery] StudentCourseScheduleQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}