using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.LessonCommands
{
    public class LessonDeleteCommandHandler : IRequestHandler<LessonDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public LessonDeleteCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(LessonDeleteCommand request, CancellationToken cancellationToken)
        {
            Lesson existed = await _unit.LessonRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            await _unit.LessonRepository.DeleteAsync(existed);
            return existed.Id;
        }
    }
}
