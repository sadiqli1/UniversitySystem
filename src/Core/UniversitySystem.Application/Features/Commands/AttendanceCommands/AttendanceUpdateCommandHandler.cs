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


            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == attendance.StudentId && p.LessonId == attendance.LessonId, "Lesson");
            List<Attendance> attendances = await _unit.AttendanceRepository.GetAllAsync(a => a.StudentId == pointList.StudentId && a.LessonId == pointList.LessonId);
            int count = default(int);
            foreach (var item in attendances)
            {
                if(item.Status == false)
                {
                    count++;
                }
            }
            await _unit.PointListRepository.UpdateAsync(pointList);
            pointList.AttendanceCount = Convert.ToByte(count);
            pointList.AttendancePoint = Convert.ToByte(100 - ((count * 100) / pointList.Lesson.LessonHour));
            if(pointList.AttendancePoint < 75)
            {
                pointList.Failed = true;
            }
            else
            {
                pointList.Failed = false;
            }
            await _unit.SaveChangesAsync();

            return attendance.Id;
        }
    }
}