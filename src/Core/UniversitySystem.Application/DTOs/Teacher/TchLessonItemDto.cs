namespace UniversitySystem.Application.DTOs.Teacher
{
    public class TchLessonItemDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int Hour { get; set; }
        public GroupInTechLessonItemDto Group { get; set; }
        public CourseInTechLessonItemDto Course { get; set; }
        public List<TechLessonDayHourInDto> LessonDayHours { get; set; }
        public List<LessonScheduleInTechLessonItemDto> LessonSchedules { get; set; }
        public List<PoinListIntechLessonItemDto> PointLists { get; set; }
    }
    public class GroupInTechLessonItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CourseInTechLessonItemDto
    {
        public int Id { get; set; }
        public byte Cours { get; set; }
        public byte Semester { get; set; }
    }
    public class TechLessonDayHourInDto
    {
        public DayHourInTechLessonDayHourInDto DayHour { get; set; }
    }
    public class DayHourInTechLessonDayHourInDto
    {
        public TechDayInDto Day { get; set; }
        public TechHourInDto Hour { get; set; }
    }
    public class TechDayInDto
    {
        public string Name { get; set; }
    }
    public class TechHourInDto
    {
        public string Name { get; set; }
    }
    public class LessonScheduleInTechLessonItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class AttendanceInTechLessonItemDto
    {
        public bool Status { get; set; }
    }
    public class PoinListIntechLessonItemDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public byte SDF1 { get; set; }
        public byte SDF2 { get; set; }
        public byte SDF3 { get; set; }
        public byte TSI { get; set; }
    }
}