using MediatR;
using UniversitySystem.Application.DTOs.Teacher;

namespace UniversitySystem.Application.Features.Queries.TeacherQueries
{
    public class TeacherGetQuery: IRequest<TeacherItemDto>
    {
        public string UserName { get; set; }
    }
}