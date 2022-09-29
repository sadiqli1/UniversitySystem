using MediatR;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class ReExamCreateCommand: IRequest<int>
    {
        public int Id;
        public byte Point { get; set; }
    }
}