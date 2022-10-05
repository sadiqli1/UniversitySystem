using MediatR;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupCreateCommand: IRequest<int>
    {
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public int CourseId { get; set; }
    }
}
