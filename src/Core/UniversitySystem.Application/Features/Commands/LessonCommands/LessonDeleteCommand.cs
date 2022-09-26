using MediatR;

namespace UniversitySystem.Application.Features.Commands.LessonCommands
{
    public class LessonDeleteCommand: IRequest<int>
    {
        public readonly int Id;
        public LessonDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
