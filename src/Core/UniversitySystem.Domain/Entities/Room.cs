using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Room: BaseEntity
    {
        public string Name { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public List<Book> Books { get; set; }
        public List<Journal> Journals { get; set; }
    }
}
