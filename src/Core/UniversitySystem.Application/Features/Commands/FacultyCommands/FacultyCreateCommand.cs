
using MediatR;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyCreateCommand: IRequest<int>
    {
        public string Name { get; set; }
        public FacultyCreateCommand(string name)
        {
            Name = name;
        }
    }
}