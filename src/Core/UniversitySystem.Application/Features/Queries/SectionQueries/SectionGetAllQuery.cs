using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.DTOs.Section;

namespace UniversitySystem.Application.Features.Queries.SectionQueries
{
    public class SectionGetAllQuery: IRequest<List<SectionItemDto>>
    {
    }
}
