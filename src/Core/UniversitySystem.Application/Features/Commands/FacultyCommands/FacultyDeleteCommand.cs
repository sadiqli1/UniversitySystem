
using MediatR;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyDeleteCommand: IRequest<int>
    {
        public readonly int Id;
        public FacultyDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
