using MediatR;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupUpdateCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecializationId { get; set; }
        public int CourseId { get; set; }
        public GroupUpdateCommand(int id)
        {
            Id = id;
        }
    }
}