using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class LessonRepository: GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(UniversityDbContext context): base(context)
        {

        }
    }
}
