using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceUpdateCommandHandler : IRequestHandler<AttendanceUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public AttendanceUpdateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(AttendanceUpdateCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = await _unit.AttendanceRepository.GetByIdAsync(request.Id);
            if (attendance == null) return 0;
            await _unit.AttendanceRepository.UpdateAsync(attendance);
            attendance.Status = request.Status;
            await _unit.SaveChangesAsync();

            List<PointList> points = await _unit.PointListRepository.GetAllAsync(p => p.StudentId == attendance.StudentId && p.LessonId == attendance.LessonId, "Lesson");
            foreach (PointList point in points)
            {
                await _unit.PointListRepository.UpdateAsync(point);
                if (attendance.Status == true)
                {
                    point.AttendanceCount -= 1;
                    int a = 100 / point.Lesson.LessonHour;
                    point.AttendancePoint += Convert.ToByte(a);
                }
                if (attendance.Status == false)
                {
                    point.AttendanceCount += 1;
                    int a = 100 / point.Lesson.LessonHour;
                    point.AttendancePoint -= Convert.ToByte(a);
                }
                await _unit.SaveChangesAsync();
            }

            return attendance.Id;
        }
    }
}