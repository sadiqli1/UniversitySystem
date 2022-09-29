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
        public IGroupRepository GroupRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public ILessonRepository LessonRepository { get; }
        public ILessonDayHourRepository LessonDayHourRepository{ get; }
        public IAttendanceRepository AttendanceRepository { get; }
        public ILessonScheduleRepository LessonScheduleRepository { get; }
        public IDayHourRepository DayHourRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public IPointListRepository PointListRepository { get; }
        Task SaveChangesAsync();
    }
}
