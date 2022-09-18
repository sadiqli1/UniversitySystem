
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyDeleteCommandHandler : IRequestHandler<FacultyDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacultyDeleteCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(FacultyDeleteCommand request, CancellationToken cancellationToken)
        {
            Faculty existed = await _unit.FacultyRepository.GetByIdAsync(request.Id, "Specializations");
            if (existed == null) return 0;
            if (existed.Specializations.Count != 0) return -1;
            await _unit.FacultyRepository.DeleteAsync(existed);
            return existed.Id;
        }
    }
}
