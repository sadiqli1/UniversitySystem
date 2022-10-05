using MediatR;
using UniversitySystem.Application.DTOs.Student;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentGetQuery: IRequest<StudentItemDto>
    {
        public string Username { get; set; }
    }
}