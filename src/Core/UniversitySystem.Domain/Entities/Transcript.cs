using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Transcript: BaseEntity
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int OnlineServiceId { get; set; }
        public OnlineService OnlineService { get; set; }
    }
}
