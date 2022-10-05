using MediatR;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class TSICreateCommand: IRequest<int>
    {
        public int StudentId;
        public int LessonId;
        public string TeacherUsername;
        public byte Point { get; set; }
    }
}