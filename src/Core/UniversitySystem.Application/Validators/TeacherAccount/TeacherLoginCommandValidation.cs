using FluentValidation;
using UniversitySystem.Application.Features.Commands.TeacherAccountCommand;

namespace UniversitySystem.Application.Validators.TeacherAccount
{
    public class TeacherLoginCommandValidation: AbstractValidator<UserLoginCommand>
    {
        public TeacherLoginCommandValidation()
        {
            RuleFor(t => t.PersonalNumber).NotEmpty().MaximumLength(9).MinimumLength(9);
            RuleFor(t => t.Password).NotEmpty();
        }
    }
}
