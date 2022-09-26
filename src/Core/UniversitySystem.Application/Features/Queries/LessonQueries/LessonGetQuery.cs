using MediatR;
using UniversitySystem.Application.DTOs.Lesson;

namespace UniversitySystem.Application.Features.Queries.LessonQueries
{
    public class LessonGetQuery: IRequest<LessonItemDto>
    {
        public readonly int Id;
        public LessonGetQuery(int id)
        {
            Id = id;
        }
    }
}
