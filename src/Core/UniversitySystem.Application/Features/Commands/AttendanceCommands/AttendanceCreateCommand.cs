using MediatR;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceCreateCommand: IRequest<int>
    {
        public bool? Status { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public int LessonScheduleId { get; set; }
        public string TeacherUsername { get; set; }
    }
}