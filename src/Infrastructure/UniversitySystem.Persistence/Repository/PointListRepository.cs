using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class PointListRepository: GenericRepository<PointList>, IPointListRepository
    {
        public PointListRepository(UniversityDbContext context): base(context)
        {

        }
    }
}