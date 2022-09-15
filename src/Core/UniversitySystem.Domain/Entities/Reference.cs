using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Reference: BaseEntity
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int ReferenceTypeId { get; set; }
        public ReferenceType ReferenceType { get; set; }
        public string PlaceToPresent { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int OnlineServiceId { get; set; }
        public OnlineService OnlineService { get; set; }
    }
}
