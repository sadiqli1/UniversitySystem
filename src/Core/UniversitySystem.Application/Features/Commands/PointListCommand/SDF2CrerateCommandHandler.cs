using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SDF2CrerateCommandHandler : IRequestHandler<SDF2CreateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public SDF2CrerateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(SDF2CreateCommand request, CancellationToken cancellationToken)
        {
            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == request.StudentId && p.LessonId == request.LessonId);

            if (pointList == null) return 0;

            if (pointList.Failed == true) throw new BadRequestException() { Code = "failed", Description = "this student failed" };

            await _unit.PointListRepository.UpdateAsync(pointList);

            pointList.SDF2 = request.Point;
            var average = (pointList.SDF1 * 0.1) + (pointList.SDF2 * 0.1) + (pointList.SDF3 * 0.1) + (pointList.TSI * 0.1) + (pointList.AttendancePoint * 0.1);
            pointList.ExamEntranceScore = Convert.ToByte(average);

            await _unit.SaveChangesAsync();
            return pointList.Id;
        }
    }
}