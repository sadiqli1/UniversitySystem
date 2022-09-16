using MediatR;

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorDeleteCommand: IRequest<int>
    {
        public int Id { get; set; }
        public SectorDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
