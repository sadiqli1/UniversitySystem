namespace UniversitySystem.Application.DTOs.Student
{
    public class StudentEJurnalDto
    {
        public LessonInStudentEJurnalDto Lesson { get; set; }

    }
    public class LessonInStudentEJurnalDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int LessonHour { get; set; }
        public byte AttendanceLimit { get; set; }
        public byte QbCount { get; set; }
        public TeacherLessonInStudentEJurnalDto Teacher { get; set; }
    }
    public class TeacherLessonInStudentEJurnalDto
    {
        public PersonInTeacherLessonInStudentEJurnalDto Person { get; set; }
    }
    public class PersonInTeacherLessonInStudentEJurnalDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}