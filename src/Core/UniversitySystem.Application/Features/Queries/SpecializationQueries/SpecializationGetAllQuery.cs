using MediatR;
using UniversitySystem.Application.DTOs.Specialization;

namespace UniversitySystem.Application.Features.Queries.SpecializationQueries
{
    public class SpecializationGetAllQuery: IRequest<List<SpecializationItemDto>>
    {
    }
}
