using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class LessonSchedule: BaseEntity
    {
        public DateTime Date { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}