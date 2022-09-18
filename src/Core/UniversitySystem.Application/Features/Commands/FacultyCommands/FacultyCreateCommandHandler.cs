
using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.FacultyCommands
{
    public class FacultyCreateCommandHandler : IRequestHandler<FacultyCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacultyCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(FacultyCreateCommand request, CancellationToken cancellationToken)
        {
            List<Faculty> faculties = await _unit.FacultyRepository.GetAllAsync(f => f.Name == request.Name);
            if (faculties.Count != 0) return 0;
            Faculty faculty = _mapper.Map<Faculty>(request);
            await _unit.FacultyRepository.AddAsync(faculty);
            return faculty.Id;
        }
    }
}