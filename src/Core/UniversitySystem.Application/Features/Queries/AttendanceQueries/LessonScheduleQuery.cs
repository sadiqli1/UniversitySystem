using MediatR;
using UniversitySystem.Application.DTOs.Attendance;

namespace UniversitySystem.Application.Features.Queries.AttendanceQueries
{
    public class LessonScheduleQuery: IRequest<List<LessonScheduleDto>>
    {
        public int lessonId;
    }
}