using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class FacultyRepository: GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(UniversityDbContext context) :base(context)
        {

        }
    }
}