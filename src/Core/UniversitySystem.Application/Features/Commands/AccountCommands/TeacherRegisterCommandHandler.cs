
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class TeacherRegisterCommandHandler : IRequestHandler<TeacherRegisterCommand, int>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public TeacherRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
        }
        public async Task<int> Handle(TeacherRegisterCommand request, CancellationToken cancellationToken)
        {
            Person teacher = await _usermanager.FindByNameAsync(request.Username);

            if (teacher != null) return 0;
            return 1;
        }
    }
}
