namespace UniversitySystem.Application.DTOs.Lesson
{
    public class LessonItemDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public GroupInLessonItemDto Group { get; set; }
        public CourseInLessonItemDto Course { get; set; }
        public TeacherInLessonItemDto Teacher { get; set; }
    }
    public class GroupInLessonItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CourseInLessonItemDto
    {
        public int Id { get; set; }
        public byte Cours { get; set; }
        public byte Semester { get; set; }
    }
    public class TeacherInLessonItemDto
    {
        public int Id { get; set; }
        public PersonInTeacherInLessonItemDto Person { get; set; }
    }
    public class PersonInTeacherInLessonItemDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
