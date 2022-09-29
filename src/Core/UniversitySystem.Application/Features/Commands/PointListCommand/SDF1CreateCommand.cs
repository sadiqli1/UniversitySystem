using MediatR;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SDF1CreateCommand: IRequest<int>
    {
        public int Id;
        public byte Point { get; set; }
    }
}