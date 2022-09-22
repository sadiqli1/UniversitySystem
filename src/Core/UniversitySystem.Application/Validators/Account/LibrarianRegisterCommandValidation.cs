using FluentValidation;
using FluentValidation.Results;
using UniversitySystem.Application.Features.Commands.AccountCommands;

namespace UniversitySystem.Application.Validators.Account
{
    public class LibrarianRegisterCommandValidation: AbstractValidator<LibrarianRegisterCommand>
    {
        public LibrarianRegisterCommandValidation()
        {
            RuleFor(t => t.Name).MaximumLength(15).NotEmpty();
            RuleFor(t => t.Surname).MaximumLength(20).NotEmpty();
            RuleFor(t => t.Surname).MaximumLength(15).NotEmpty();
            RuleFor(t => t.PersonalNumber).MaximumLength(9).MinimumLength(9).NotEmpty();
            RuleFor(t => t.Email).MaximumLength(50).NotEmpty();
            RuleFor(t => t).Custom((r, context) =>
            {
                if (r.Password != r.ConfirmPassword) context.AddFailure(new ValidationFailure("Password", "Password and confirm password does not match."));
                if (!r.Email.Contains("@std.beu.edu.az")) context.AddFailure(new ValidationFailure("Email", "is not valid email address"));
            });
        }
    }
}
