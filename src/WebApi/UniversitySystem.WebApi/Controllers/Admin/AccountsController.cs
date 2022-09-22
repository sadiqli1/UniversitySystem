using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.Features.Commands.AccountCommands;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.WebApi.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _rolemanager;

        public AccountsController(IMediator mediator, RoleManager<IdentityRole> roleManager)
        {
            _mediator = mediator;
            _rolemanager = roleManager;
        }
        [HttpPost("teacherregister")]
        public async Task<IActionResult> TeacherRegister(TeacherRegisterCommand command)
        {
            PersonRegisterDto dto = await _mediator.Send(command);

            if (dto == null) return BadRequest();

            return StatusCode(StatusCodes.Status201Created, dto);
        }
        [HttpPost("studentregister")]
        public async Task<IActionResult> StudentRegister(StudentRegisterCommand command)
        {
            PersonRegisterDto dto = await _mediator.Send(command);

            if (dto == null) return BadRequest();

            return StatusCode(StatusCodes.Status201Created, dto);
        }
        [HttpPost("librarianregister")]
        public async Task<IActionResult> LibrarianRegister(LibrarianRegisterCommand command)
        {
            PersonRegisterDto dto = await _mediator.Send(command);

            if (dto == null) return BadRequest();

            return StatusCode(StatusCodes.Status201Created, dto);
        }

        #region
        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _rolemanager.CreateAsync(new IdentityRole("Student"));
        //    await _rolemanager.CreateAsync(new IdentityRole("Teacher"));
        //    await _rolemanager.CreateAsync(new IdentityRole("Tytor"));
        //    await _rolemanager.CreateAsync(new IdentityRole("Dean"));
        //    await _rolemanager.CreateAsync(new IdentityRole("Librarian"));
        //    await _rolemanager.CreateAsync(new IdentityRole("EducationDepartment"));

        //    return NoContent();
        //}
        #endregion
    }
}