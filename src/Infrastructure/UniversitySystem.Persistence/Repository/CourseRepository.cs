using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class CourseRepository: GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityDbContext context): base(context)
        {
        }
    }
}
