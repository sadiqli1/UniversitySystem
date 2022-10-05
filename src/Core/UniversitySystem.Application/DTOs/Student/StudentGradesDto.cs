namespace UniversitySystem.Application.DTOs.Student
{
    public class StudentGradesDto
    {
        public byte SDF1 { get; set; } = 0;
        public byte SDF2 { get; set; } = 0;
        public byte SDF3 { get; set; } = 0;
        public byte TSI { get; set; } = 0;
        public byte AttendanceCount { get; set; } = 0;
        public byte AttendancePoint { get; set; } = 100;
        public byte SSI { get; set; } = 0;
        public byte? AdditionalExam { get; set; }
        public byte? ReExam { get; set; }
        public byte Average { get; set; } = 0;
        public byte ExamEntranceScore { get; set; } = 10;
        public bool Failed { get; set; }
        public LessonInStudentGradesDto Lesson { get; set; }
    }
    public class LessonInStudentGradesDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int LessonHour { get; set; }
        public TeacherInLessonInStudentGradesDto Teacher { get; set; }
    }
    public class TeacherInLessonInStudentGradesDto
    {
        public PersonTeacherInLessonInStudentGradesDto Person { get; set; }
    }
    public class PersonTeacherInLessonInStudentGradesDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}