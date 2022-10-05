namespace UniversitySystem.Application.DTOs.Teacher
{
    public class TeacherItemDto
    {
        public PersonInTeacherItemDto Person { get; set; }
        public SectionInTeacherItemDto Section { get; set; }
    }
    public class PersonInTeacherItemDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDay { get; set; }
        public string PersonalNumber { get; set; }
    }
    public class SectionInTeacherItemDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}