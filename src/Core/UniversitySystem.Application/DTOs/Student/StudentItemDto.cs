namespace UniversitySystem.Application.DTOs.Student
{
    public class StudentItemDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthDay { get; set; }
        public string PersonalNumber { get; set; }
        public bool Status { get; set; }
        public int TuitionDebt { get; set; }    
        public bool TuitionfeePayment { get; set; }
        public decimal Score { get; set; }
        public bool OrderbyState { get; set; }
        public bool RetirebyPresident { get; set; }
        public GroupInStudentItemDto Group { get; set; }
    }
    public class GroupInStudentItemDto
    {
        public string Name { get; set; }
    }
}