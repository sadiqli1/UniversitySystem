using MediatR;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceUpdateCommand: IRequest<int>
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        //public int LessonId { get; set; }
        //public int StudentId { get; set; }
        //public int LessonScheduleId { get; set; }
    }
}