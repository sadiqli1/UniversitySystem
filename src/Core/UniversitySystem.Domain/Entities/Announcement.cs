using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Announcement: BaseEntity
    {
        public string Title { get; set; }
        public string toWhom { get; set; }
        public string Article { get; set; }
        public DateTime CreateAt { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
