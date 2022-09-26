using MediatR;
using UniversitySystem.Application.DTOs.Lesson;

namespace UniversitySystem.Application.Features.Queries.LessonQueries
{
    public class LessonGetAllQuery: IRequest<List<LessonItemDto>>
    {
    }
}
