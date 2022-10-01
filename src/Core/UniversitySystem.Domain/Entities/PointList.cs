using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Domain.Entities.Base;

namespace UniversitySystem.Domain.Entities
{
    public class PointList: BaseEntity
    {
        public byte SDF1 { get; set; } = 0;
        public byte SDF2 { get; set; } = 0;
        public byte SDF3 { get; set; } = 0;
        public byte TSI { get; set; } = 0;
        public byte AttendanceCount { get; set; } = 0;
        public byte AttendancePoint { get; set; } = 100;
        public byte SSI { get; set; } = 0;
        public byte? AdditionalExam { get; set; }
        public byte? ReExam { get; set; }
        public byte Average { get; set; } = 0;
        public byte ExamEntranceScore { get; set; } = 10;
        public bool Failed { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
