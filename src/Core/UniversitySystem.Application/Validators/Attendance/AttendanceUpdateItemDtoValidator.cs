using FluentValidation;
using UniversitySystem.Application.DTOs.Attendance;

namespace UniversitySystem.Application.Validators.Attendance
{
    public class AttendanceUpdateItemDtoValidator: AbstractValidator<AttendanceUpdateItemDto>
    {
        public AttendanceUpdateItemDtoValidator()
        {
            RuleFor(a => a.Status).NotEmpty();
        }
    }
}