using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupCreateCommandHandler : IRequestHandler<GroupCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public GroupCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(GroupCreateCommand request, CancellationToken cancellationToken)
        {
            List<Group> existed = await _unit.GroupRepository
                .GetAllAsync(g => g.Name.Trim().ToLower() == request.Name.Trim().ToLower(), "Specialization", "Course");
            if (existed.Count != 0) return 0;
            Specialization specialization = await _unit.SpecializationRepository.GetByIdAsync(request.SpecializationId);    
            Course course = await _unit.CourseRepository.GetByIdAsync(request.CourseId);
            if(specialization == null || course == null) return -1;
            Group group = _mapper.Map<Group>(request);
            await _unit.GroupRepository.AddAsync(group);
            return group.Id;
        }
    }
}