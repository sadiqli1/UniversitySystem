using MediatR;
using UniversitySystem.Application.DTOs.Section;

namespace UniversitySystem.Application.Features.Queries.SectionQueries
{
    public class SectionGetAllQuery: IRequest<List<SectionItemDto>>
    {
    }
}