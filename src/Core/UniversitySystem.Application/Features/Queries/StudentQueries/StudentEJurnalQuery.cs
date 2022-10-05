using MediatR;
using UniversitySystem.Application.DTOs.Student;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentEJurnalQuery: IRequest<List<StudentEJurnalDto>>
    {
        public string Username { get; set; }
    }
}