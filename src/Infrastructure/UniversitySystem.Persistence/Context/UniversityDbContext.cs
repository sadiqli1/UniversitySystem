using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Domain.Entities;
using UniversitySystem.Persistence.Configuration;

namespace UniversitySystem.Persistence.Context
{
    public class UniversityDbContext: IdentityDbContext<Person>
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options): base(options)
        {

        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ParticipationList> ParticipationLists { get; set; }
        public DbSet<PointList> PointLists { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<EducationDepartment> EducationDepartments { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<DayHour> DayHours { get; set; }
        public DbSet<LessonDayHour> LessonDayHours { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LessonSchedule> LessonSchedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SectorConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new PersonRegisterConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new PointListConfiguration());

            modelBuilder.Entity<Lesson>().HasOne(x => x.Group).WithMany(x => x.Lessons).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().HasOne(x => x.Group).WithMany(x => x.Students).HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Teacher>().HasOne(x => x.Duty).WithMany(x => x.Teachers).HasForeignKey(x => x.DutyId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Teacher>().HasOne(x => x.Section).WithMany(x => x.Teachers).HasForeignKey(x => x.SectionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LessonSchedule>().HasOne(c => c.Lesson).WithMany(c => c.LessonSchedules).HasForeignKey(c => c.LessonId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Person>().HasOne(p => p.EducationDepartment).WithOne(p => p.Person).HasForeignKey<EducationDepartment>(e => e.PersonId);
            modelBuilder.Entity<Person>().HasOne(p => p.Teacher).WithOne(p => p.Person).HasForeignKey<Teacher>(e => e.PersonId);
            modelBuilder.Entity<Person>().HasOne(p => p.Student).WithOne(p => p.Person).HasForeignKey<Student>(e => e.PersonId);
            modelBuilder.Entity<LessonSchedule>().HasOne(x => x.Attendance).WithOne(x => x.LessonSchedule).HasForeignKey<Attendance>(e => e.LessonScheduleId);
            base.OnModelCreating(modelBuilder);
        }
    }
}