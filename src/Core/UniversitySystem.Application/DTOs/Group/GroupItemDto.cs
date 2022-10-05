namespace UniversitySystem.Application.DTOs.Group
{
    public class GroupItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SpecializationInGroup Specialization { get; set; }
        public CourseInGroup Course { get; set; }
        //public TeacherInGroup Teacher { get; set; }
    }
    public class SpecializationInGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class CourseInGroup
    {
        public int Id { get; set; }
        public byte Cours { get; set; }
        public byte Semester { get; set; }
    }
    //public class TeacherInGroup
    //{
    //    public PersonInTeacher Person { get; set; }
    //}
    //public class PersonInTeacher
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //}
}