using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.DTOs.Sector;

namespace UniversitySystem.Application.Features.Queries.SectorQueries
{
    public class SectorGetAllQuery: IRequest<List<SectorGetItemDto>>
    {
        
    }
}
