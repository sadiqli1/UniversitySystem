
using MediatR;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.TeacherAccountCommand
{
    public class UserLoginCommand: IRequest<string>
    {
        public string PersonalNumber { get; set; }
        public string Password { get; set; }
    }
}
