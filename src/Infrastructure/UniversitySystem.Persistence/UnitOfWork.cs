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
        public IGroupRepository GroupRepository { get => new GroupRepository(_context) ?? throw new NotImplementedException(); }
        public ICourseRepository CourseRepository { get => new CourseRepository(_context) ?? throw new NotImplementedException(); }
        public ITeacherRepository TeacherRepository { get => new TeacherRepository(_context) ?? throw new NotImplementedException(); }
        public ILessonRepository LessonRepository { get => new LessonRepository(_context) ?? throw new NotImplementedException(); }
        public ILessonDayHourRepository LessonDayHourRepository { get => new LessonDayHourRepository(_context) ?? throw new NotImplementedException(); }
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
