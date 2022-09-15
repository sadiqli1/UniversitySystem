using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UniversitySystem.Application.DTOs.Specialization;

namespace UniversitySystem.Application.Validators.Specialization
{
    public class SpecializationPostDtoValidation: AbstractValidator<SpecializationPostDto>
    {
        public SpecializationPostDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Code).NotEmpty().LessThanOrEqualTo(99999).GreaterThanOrEqualTo(10000);
            RuleFor(x => x.Duration).NotEmpty();
        }
    }
}