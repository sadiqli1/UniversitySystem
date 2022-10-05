using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Group;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.GroupQueries
{
    public class GroupGetQueryHandler : IRequestHandler<GroupGetQuery, GroupItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public GroupGetQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<GroupItemDto> Handle(GroupGetQuery request, CancellationToken cancellationToken)
        {
            Group group = await _unit.GroupRepository.GetByIdAsync(request.Id, "Specialization", "Course");
            GroupItemDto dto = _mapper.Map<GroupItemDto>(group);
            return dto;
        }
    }
}