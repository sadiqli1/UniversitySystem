using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Journal: BaseEntity
    {
        public string Name { get; set; }
        public int ISSN { get; set; }
        public string PublishersName { get; set; }
        public DateTime PublicationYear { get; set; }
        public int PageCount { get; set; }
        public byte Series { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
