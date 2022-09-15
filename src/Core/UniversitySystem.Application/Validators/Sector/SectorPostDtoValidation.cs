using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UniversitySystem.Application.DTOs.Sector;

namespace UniversitySystem.Application.Valitations
{
    public class SectorPostDtoValidation: AbstractValidator<SectorPostDto>
    {
        public SectorPostDtoValidation()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(20);
        }
    }
}
