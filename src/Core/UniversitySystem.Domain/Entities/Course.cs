using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Course: BaseEntity
    {
        public byte Cours { get; set; }
        public byte Semester { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Group> Groups { get; set; }
    }
}
