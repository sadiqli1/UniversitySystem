using MediatR;
using UniversitySystem.Application.DTOs.Sector;

namespace UniversitySystem.Application.Features.Queries.SectorQueries
{
    public class SectorGetAllQuery: IRequest<List<SectorGetItemDto>>
    {
        
    }
}