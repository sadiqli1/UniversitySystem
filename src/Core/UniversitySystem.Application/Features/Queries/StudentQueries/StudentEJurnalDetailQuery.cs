using MediatR;
using UniversitySystem.Application.DTOs.Student;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentEJurnalDetailQuery: IRequest<List<StudentEJurnalDetailDto>>
    {
        public int LessonId { get; set; }
    }
}