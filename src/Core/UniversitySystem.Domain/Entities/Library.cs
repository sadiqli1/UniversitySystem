using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Library: BaseEntity
    {
        public string Name { get; set; }
        public List<Librarian> Librarians { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
