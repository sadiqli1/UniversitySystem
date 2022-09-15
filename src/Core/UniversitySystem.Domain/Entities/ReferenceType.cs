using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class ReferenceType: BaseEntity
    {
        public string Name { get; set; }
        public List<Reference> References { get; set; }
    }
}
