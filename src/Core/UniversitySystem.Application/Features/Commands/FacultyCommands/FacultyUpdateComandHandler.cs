
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyUpdateComandHandler : IRequestHandler<FacultyUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacultyUpdateComandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(FacultyUpdateCommand request, CancellationToken cancellationToken)
        {
            Faculty existed = await _unit.FacultyRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            List<Faculty> faculties = await _unit.FacultyRepository.GetAllAsync(s => s.Name == request.Name && existed.Name != request.Name);
            if (faculties.Count != 0) return 0;
            await _unit.FacultyRepository.UpdateAsync(existed);
            existed.Name = request.Name;
            await _unit.SaveChangesAsync();
            return request.Id;
        }
    }
}
