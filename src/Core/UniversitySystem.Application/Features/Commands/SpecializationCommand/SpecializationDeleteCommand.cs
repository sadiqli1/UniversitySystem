
using MediatR;

namespace UniversitySystem.Application.Features.Commands.SpecializationCommand
{
    public class SpecializationDeleteCommand: IRequest<int>
    {
        public int Id { get; set; }
        public SpecializationDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
