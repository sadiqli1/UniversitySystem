using FluentValidation;
using UniversitySystem.Application.DTOs.Lesson;

namespace UniversitySystem.Application.Validators.Lesson
{
    public class LessonPostDtoValidator: AbstractValidator<LessonPostDto>
    {
        public LessonPostDtoValidator()
        {
            RuleFor(l => l.Name).NotEmpty().MaximumLength(50);
            RuleFor(l => l.Code).NotEmpty().MaximumLength(15);
            RuleFor(l => l.Theory).NotEmpty();
            RuleFor(l => l.Practice).NotEmpty();
            RuleFor(l => l.Ects).NotEmpty();
        }
    }
}