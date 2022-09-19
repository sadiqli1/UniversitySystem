
using MediatR;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class TeacherRegisterCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDay { get; set; }
        public int PersonalNumber { get; set; }
        public TeacherInPerson Teacher { get; set; }
    }
    public class TeacherInPerson
    {
        public int DutyId { get; set; }
        public int SectionId { get; set; }
    }
}
