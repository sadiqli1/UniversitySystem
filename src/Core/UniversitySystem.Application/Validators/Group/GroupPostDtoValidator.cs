using FluentValidation;
using UniversitySystem.Application.DTOs.Group;

namespace UniversitySystem.Application.Validators.Group
{
    public class GroupPostDtoValidator: AbstractValidator<GroupPostDto>
    {
        public GroupPostDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(5).MinimumLength(5);
        }
    }
}