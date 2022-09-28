using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class LessonScheduleRepository: GenericRepository<LessonSchedule>, ILessonScheduleRepository
    {
        public LessonScheduleRepository(UniversityDbContext context): base(context)
        {

        }
    }
}