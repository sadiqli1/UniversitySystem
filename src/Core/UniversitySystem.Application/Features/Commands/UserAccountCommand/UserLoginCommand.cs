
using MediatR;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.UserAccountCommand
{
    public class UserLoginCommand: IRequest<string>
    {
        public string PersonalNumber { get; set; }
        public string Password { get; set; }
    }
}
