using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class SectionRepository: GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(UniversityDbContext context): base(context)
        {

        }
    }
}