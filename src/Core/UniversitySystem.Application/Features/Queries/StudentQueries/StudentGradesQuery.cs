using MediatR;
using UniversitySystem.Application.DTOs.Student;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentGradesQuery: IRequest<List<StudentGradesDto>>
    {
        public string Username { get; set; }
    }
}