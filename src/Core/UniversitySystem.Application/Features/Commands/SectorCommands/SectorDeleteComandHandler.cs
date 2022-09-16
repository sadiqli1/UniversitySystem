using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorDeleteComandHandler : IRequestHandler<SectorDeleteCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SectorDeleteComandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(SectorDeleteCommand request, CancellationToken cancellationToken)
        {
            Sector existed = await _unit.SectorRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            await _unit.SectorRepository.DeleteAsync(existed);
            return request.Id;
        }
    }
}
