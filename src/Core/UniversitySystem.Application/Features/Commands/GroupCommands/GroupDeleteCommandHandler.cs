using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupDeleteCommandHandler : IRequestHandler<GroupDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public GroupDeleteCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(GroupDeleteCommand request, CancellationToken cancellationToken)
        {
            Group existed = await _unit.GroupRepository.GetByIdAsync(request.Id, "Lessons", "Students");
            if (existed == null) return 0;
            if (existed.Lessons.Count != 0 || existed.Students.Count != 0) return -1;
            await _unit.GroupRepository.DeleteAsync(existed);
            return request.Id;
        }
    }
}