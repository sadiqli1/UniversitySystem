using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.DTOs.Specialization;

namespace UniversitySystem.Application.Features.Queries.SpecializationQueries
{
    public class SpecializationGetQuery: IRequest<SpecializationItemDto>
    {
        public int Id { get; set; }
        public SpecializationGetQuery(int id)
        {
            Id = id;
        }
    }
}
