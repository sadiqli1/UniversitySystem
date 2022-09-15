using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Language: BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public List<Journal> Journals { get; set; }
        public List<Transcript> Transcripts { get; set; }
        public List<Reference> References { get; set; }
    }
}
