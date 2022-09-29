using MediatR;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SDF3CreateCommand: IRequest<int>
    {
        public byte Point { get; set; }
    }
}