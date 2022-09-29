using FluentValidation;
using FluentValidation.Results;
using UniversitySystem.Application.DTOs.Point;

namespace UniversitySystem.Application.Validators.PointList
{
    public class PoinPostDtoValidator: AbstractValidator<PointPostDto>
    {
        public PoinPostDtoValidator()
        {
            RuleFor(p => p).Custom((p, context) =>
            {
                if (p.Point > 100) context.AddFailure(new ValidationFailure("size", "max size 100"));
                if (p.Point < 0) context.AddFailure(new ValidationFailure("size", "min size 0"));
            });
        }
    }
}