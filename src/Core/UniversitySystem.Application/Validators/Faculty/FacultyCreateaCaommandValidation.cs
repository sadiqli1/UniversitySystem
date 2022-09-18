using FluentValidation;
using UniversitySystem.Application.Features.Commands.FacultyCommands;

namespace UniversitySystem.Application.Validators.Faculty
{
    public class FacultyCreateaCaommandValidation: AbstractValidator<FacultyCreateCommand>
    {
        public FacultyCreateaCaommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}