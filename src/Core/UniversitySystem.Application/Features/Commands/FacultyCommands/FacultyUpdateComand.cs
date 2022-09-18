
using MediatR;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyUpdateCommand: IRequest<int>
    {
        public readonly int Id;
        public string Name { get; set; }
        public FacultyUpdateCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
