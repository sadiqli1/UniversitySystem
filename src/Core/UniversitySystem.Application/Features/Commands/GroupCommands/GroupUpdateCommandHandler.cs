using AutoMapper;
using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.GroupCommands
{
    public class GroupUpdateCommandHandler : IRequestHandler<GroupUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public GroupUpdateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(GroupUpdateCommand request, CancellationToken cancellationToken)
        {
            Group existed = await _unit.GroupRepository.GetByIdAsync(request.Id);
            if (existed == null) return 0;
            List<Group> groups = await _unit.GroupRepository
                .GetAllAsync(s => s.Name.Trim().ToLower() == request.Name.Trim().ToLower() && existed.Name.Trim().ToLower() != request.Name.Trim().ToLower());
            if (groups.Count != 0) return 0;
            Specialization specialization = await _unit.SpecializationRepository.GetByIdAsync(request.SpecializationId);
            Course course = await _unit.CourseRepository.GetByIdAsync(request.CourseId);
            Teacher teacher = await _unit.TeacherRepository.GetByIdAsync(request.TeacherId);
            if (specialization == null || course == null || teacher == null) return -1;
            await _unit.GroupRepository.UpdateAsync(existed);
            Group group = _mapper.Map<Group>(request);
            await _unit.SaveChangesAsync();
            return group.Id;
        }
    }
}
