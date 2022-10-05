using MediatR;
using UniversitySystem.Application.DTOs.Student;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentCourseScheduleQuery: IRequest<List<StudentCourseScheduleDto>>
    {
        public string Username { get; set; }
    }
}