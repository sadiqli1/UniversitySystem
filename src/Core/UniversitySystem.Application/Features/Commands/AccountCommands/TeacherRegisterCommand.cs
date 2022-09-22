
using MediatR;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class TeacherRegisterCommand: IRequest<PersonRegisterDto>
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
        public TeacherInPerson Teacher { get; set; }
    }
    public class TeacherInPerson
    {
        public int SectionId { get; set; }
    }
}
