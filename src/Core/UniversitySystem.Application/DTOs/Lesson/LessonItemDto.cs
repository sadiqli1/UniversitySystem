namespace UniversitySystem.Application.DTOs.Lesson
{
    public class LessonItemDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int Hour { get; set; }
        public GroupInLessonItemDto Group { get; set; }
        public CourseInLessonItemDto Course { get; set; }
        public TeacherInLessonItemDto Teacher { get; set; }
        public List<LessonDayHourInDto> LessonDayHours { get; set; }
        public List<LessonScheduleInLessonItemDto> LessonSchedules { get; set; }
        public List<PoinListInLessonItemDto> PointLists { get; set; }
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
    public class LessonDayHourInDto
    {
        public DayHourInLessonDayHourInDto DayHour { get; set; }
    }
    public class DayHourInLessonDayHourInDto
    {
        public DayInDto Day { get; set; }
        public HourInDto Hour { get; set; }
    }
    public class DayInDto
    {
        public string Name { get; set; }
    }
    public class HourInDto
    {
        public string Name { get; set; }
    }
    public class LessonScheduleInLessonItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class AttendanceInLessonItemDto
    {
        public bool Status { get; set; }
    }
    public class PoinListInLessonItemDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public byte SDF1 { get; set; }
        public byte SDF2 { get; set; }
        public byte SDF3 { get; set; }
        public byte TSI { get; set; }
    }
}