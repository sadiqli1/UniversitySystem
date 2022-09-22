
using MediatR;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class StudentRegisterCommand: IRequest<PersonRegisterDto>
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
        public StudentInPerson Student { get; set; }
    }
    public class StudentInPerson
    {
        public bool Status { get; set; }
        public int TuitionDebt { get; set; }
        public bool TuitionfeePayment { get; set; }
        public decimal Score { get; set; }
        public bool OrderbyState { get; set; }
        public bool RetirebyPresident { get; set; }
        public int GroupId { get; set; }
    }
}
