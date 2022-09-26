namespace UniversitySystem.Application.DTOs.Lesson
{
    public class LessonPostDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public List<int> DayHourIds { get; set; }
        //public DayInLessonPostDto LessonDayHour { get; set; }
    }
    //public class DayInLessonPostDto
    //{
    //    public List<int> DayHourIds { get; set; }
    //}
}