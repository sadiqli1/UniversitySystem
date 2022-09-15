using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Student: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime Birthday { get; set; }
        public int StudentNumber { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
        public int TuitionDebt { get; set; }
        public bool TuitionfeePayment { get; set; }
        public decimal Score { get; set; }
        public bool OrderbyState { get; set; }
        public bool RetirebyPresident { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public List<PointList> PointLists { get; set; }
        public List<Transcript> Transcripts { get; set; }
        public List<Reference> References { get; set; }
    }
}
