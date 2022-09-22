using MediatR;
using UniversitySystem.Application.DTOs.Account;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class LibrarianRegisterCommand: IRequest<PersonRegisterDto>
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
        public LibrarianInPerson Librarian { get; set; }
    }
    public class LibrarianInPerson
    {
        public int LibraryId { get; set; } 
    }
}