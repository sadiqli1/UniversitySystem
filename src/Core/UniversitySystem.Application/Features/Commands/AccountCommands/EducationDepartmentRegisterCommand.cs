using MediatR;
using UniversitySystem.Application.DTOs.Account;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{

    public class EducationDepartmentRegisterCommand: IRequest<PersonRegisterDto>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
