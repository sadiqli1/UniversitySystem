using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Context;

namespace UniversitySystem.Persistence.Repository
{
    public class GroupRepository: GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(UniversityDbContext context): base(context)
        {

        }
    }
}