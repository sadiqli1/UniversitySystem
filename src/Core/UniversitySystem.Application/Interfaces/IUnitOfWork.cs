using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Application.Interfaces.Repository;

namespace UniversitySystem.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ISectorRepository SectorRepository { get;}
        public ISectionRepository SectionRepository { get;}
        public ISpecializationRepository SpecializationRepository { get;}
        public IFacultyRepository FacultyRepository { get;}
        Task SaveChangesAsync();
    }
}
