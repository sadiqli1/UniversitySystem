using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SDF1CreateCommandHandler : IRequestHandler<SDF1CreateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public SDF1CreateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(SDF1CreateCommand request, CancellationToken cancellationToken)
        {
            PointList pointList = await _unit.PointListRepository.GetByIdAsync(request.Id);

            if (pointList == null) return 0;

            Student student = await _unit.StudentRepository.GetByIdAsync(pointList.StudentId, "Attendances");
            int qbCount = student.Attendances.Where(a => a.LessonId == pointList.LessonId && a.Status == false).ToList().Count();

            Lesson lesson = await _unit.LessonRepository.GetByIdAsync(pointList.LessonId);
            int limit = (lesson.LessonHour * 25) / 100;
            

            await _unit.PointListRepository.UpdateAsync(pointList);

            pointList.SDF1 = request.Point;
            var average = (pointList.SDF1 * 0.1) + (pointList.SDF2 * 0.1) + (pointList.SDF3 * 0.1) + (pointList.TSI*0.1) + (pointList.AttendancePoint*0.1);
            pointList.Average = Convert.ToByte(average);
            if (limit < qbCount)
            {
                pointList.Failed = true;
            }
            else
            {
                pointList.Failed = false;
            }
            await _unit.SaveChangesAsync();
            return pointList.Id;
        }
    }
}