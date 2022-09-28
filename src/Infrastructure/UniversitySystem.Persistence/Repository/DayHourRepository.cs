using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class DayHourRepository: GenericRepository<DayHour>, IDayHourRepository
    {
        public DayHourRepository(UniversityDbContext context): base(context)
        {

        }
    }
}