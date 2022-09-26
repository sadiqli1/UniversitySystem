using MediatR;
using UniversitySystem.Application.DTOs.Group;

namespace UniversitySystem.Application.Features.Queries.GroupQueries
{
    public class GroupGetAllQuery: IRequest<List<GroupItemDto>>
    {

    }
}
