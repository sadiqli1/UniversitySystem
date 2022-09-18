using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Configuration;

namespace UniversitySystem.Persistence.Context
{
    public class UniversityDbContext: DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options): base(options)
        {

        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<EducationDepartment> EducationDepartments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<OnlineService> OnlineServices { get; set; }
        public DbSet<ParticipationList> ParticipationLists { get; set; }
        public DbSet<PointList> PointLists { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<ReferenceType> ReferenceTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SectorConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.Entity<Lesson>().HasOne(x => x.Group).WithMany(x => x.Lessons).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().HasOne(x => x.Group).WithMany(x => x.Students).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Teacher>().HasOne(x => x.Duty).WithMany(x => x.Teachers).HasForeignKey(x => x.DutyId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Teacher>().HasOne(x => x.Section).WithMany(x => x.Teachers).HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
