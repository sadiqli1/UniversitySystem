using MediatR;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupDeleteCommand: IRequest<int>
    {
        public int Id { get; set; }
        public GroupDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
