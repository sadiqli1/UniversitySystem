using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class AttendanceRepository: GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(UniversityDbContext context): base(context)
        {

        }
    }
}