namespace UniversitySystem.Application.DTOs.Student
{
    public class StudentEJurnalDetailDto
    {
        public DateTime Date { get; set; }
        public AttendanceInStudentEJurnalDetailDto Attendance { get; set; }
    }
    public class AttendanceInStudentEJurnalDetailDto
    {
        public bool Status { get; set; }
    }
}