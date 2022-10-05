namespace UniversitySystem.Application.DTOs.Lesson
{
    public class DaysGetDto
    {
        public int Id { get; set; }
        public DayInDaysGetDto Day { get; set; }
        public HourInDaysGetDto Hour { get; set; }
    }
    public class DayInDaysGetDto
    {
        public string Name { get; set; }
    }
    public class HourInDaysGetDto
    {
        public string Name { get; set; }
    }
}