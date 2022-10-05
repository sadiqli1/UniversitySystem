using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Domain.Entities
{
    public class Person: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDay { get; set; }
        public string PersonalNumber { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public EducationDepartment EducationDepartment { get; set; }
    }
}