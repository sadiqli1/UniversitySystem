using FluentValidation;
using UniversitySystem.Application.DTOs.Faculty;

namespace UniversitySystem.Application.Validators.Faculty
{
    public class FacultyPostDtoValidation: AbstractValidator<FacultyPostDto>
    {
        public FacultyPostDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
