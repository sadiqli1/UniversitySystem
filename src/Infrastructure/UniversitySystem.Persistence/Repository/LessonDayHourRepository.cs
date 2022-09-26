using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class LessonDayHourRepository: GenericRepository<LessonDayHour>, ILessonDayHourRepository
    {
        public LessonDayHourRepository(UniversityDbContext context): base(context)
        {

        }
    }
}