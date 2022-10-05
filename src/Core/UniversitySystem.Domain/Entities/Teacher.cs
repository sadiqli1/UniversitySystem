using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Teacher: BaseEntity
    {
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        //public List<Group> Groups { get; set; }
        public List<Lesson> Lessons { get; set; }
        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}
