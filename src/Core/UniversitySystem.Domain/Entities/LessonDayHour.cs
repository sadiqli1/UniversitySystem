using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class LessonDayHour: BaseEntity
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int DayHourId { get; set; }
        public DayHour DayHour { get; set; }
    }
}