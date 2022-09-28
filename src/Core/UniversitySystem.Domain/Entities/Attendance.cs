using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Attendance: BaseEntity
    {
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonScheduleId { get; set; }
        public LessonSchedule LessonSchedule { get; set; }
    }
}