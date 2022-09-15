using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Validators.Section
{
    public class SectionPostDtoValidation: AbstractValidator<SectionPostDto>
    {
        public SectionPostDtoValidation()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Code).NotEmpty().MaximumLength(15);
        }
    }
}
