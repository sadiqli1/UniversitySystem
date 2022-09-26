using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Day: BaseEntity
    {
        public string Name { get; set; }
        public List<DayHour> DayHours { get; set; }
    }
}