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
    public class SectorRepository: GenericRepository<Sector>, ISectorRepository
    {
        public SectorRepository(UniversityDbContext context): base(context)
        {
            
        }
    }
}
