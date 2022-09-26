using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class DayHour: BaseEntity
    {
        public int DayId { get; set; }
        public Day Day { get; set; }
        public int HourId { get; set; }
        public Hour Hour { get; set; }
        public List<LessonDayHour> LessonDayHours { get; set; }
    }
}