using AutoMapper;
using MediatR;
using UniversitySystem.Application.DTOs.Group;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.GroupQueries
{
    public class GroupGetAllQueryHandler : IRequestHandler<GroupGetAllQuery, List<GroupItemDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public GroupGetAllQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<GroupItemDto>> Handle(GroupGetAllQuery request, CancellationToken cancellationToken)
        {
            List<Group> groups = await _unit.GroupRepository.GetAllAsync(null, "Specialization", "Course", "Teacher", "Teacher.Person");
            List<GroupItemDto> dtos = _mapper.Map<List<GroupItemDto>>(groups);
            return dtos;
        }
    }
}