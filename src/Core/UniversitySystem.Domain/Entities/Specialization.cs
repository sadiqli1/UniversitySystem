using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Specialization: BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public DateTime CreateAt { get; set; }
        public byte Duration { get; set; }
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public List<Group> Groups { get; set; }
    }
}
