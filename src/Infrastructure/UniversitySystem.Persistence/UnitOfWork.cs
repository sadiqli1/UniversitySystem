using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Persistence.Context;
using UniversitySystem.Persistence.Repository;

namespace UniversitySystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniversityDbContext _context;

        public ISectorRepository SectorRepository { get => new SectorRepository(_context) ?? throw new NotImplementedException();}
        public ISectionRepository SectionRepository { get => new SectionRepository(_context) ?? throw new NotImplementedException();}
        public ISpecializationRepository SpecializationRepository { get => new SpecializationRepository(_context) ?? throw new NotImplementedException();}
        public IFacultyRepository FacultyRepository { get => new FacultyRepository(_context) ?? throw new NotImplementedException();}

        public UnitOfWork(UniversityDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
