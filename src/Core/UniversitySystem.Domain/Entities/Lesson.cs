using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class Lesson: BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<PointList> PointLists { get; set; }
        public List<LessonDayHour> LessonDayHours { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<LessonSchedule> LessonSchedules { get; set; }
    }
}
