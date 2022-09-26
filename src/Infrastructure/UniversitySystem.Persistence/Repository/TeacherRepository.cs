using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class TeacherRepository: GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniversityDbContext context): base(context)
        {

        }
    }
}
