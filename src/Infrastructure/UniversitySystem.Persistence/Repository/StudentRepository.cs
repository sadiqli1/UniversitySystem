using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext context): base(context)
        {

        }
    }
}