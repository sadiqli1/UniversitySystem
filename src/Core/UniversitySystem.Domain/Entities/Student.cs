using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Student: BaseEntity
    {
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
        public bool Status { get; set; }
        public int TuitionDebt { get; set; }
        public bool TuitionfeePayment { get; set; }
        public decimal Score { get; set; }
        public bool OrderbyState { get; set; }
        public bool RetirebyPresident { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<PointList> PointLists { get; set; }
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
