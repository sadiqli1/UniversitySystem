using MediatR;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.DTOs.Teacher;

namespace UniversitySystem.Application.Features.Queries.TeacherQueries
{
    public class LessonGetQuery: IRequest<List<TchLessonItemDto>>
    {
        public string TeacherUsername { get; set; }
    }
}