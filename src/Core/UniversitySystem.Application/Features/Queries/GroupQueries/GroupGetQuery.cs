using MediatR;
using UniversitySystem.Application.DTOs.Group;

namespace UniversitySystem.Application.Features.Queries.GroupQueries
{
    public class GroupGetQuery: IRequest<GroupItemDto>
    {
        public int Id { get; set; }
        public GroupGetQuery(int id)
        {
            Id = id;
        }
    }
}
