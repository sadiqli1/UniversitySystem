using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SSICreateCommandHandler : IRequestHandler<SSICreateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public SSICreateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(SSICreateCommand request, CancellationToken cancellationToken)
        {
            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == request.StudentId && p.LessonId == request.LessonId);

            if (pointList == null) return 0;

            if (pointList.Failed == true) throw new BadRequestException() { Code = "failed", Description = "this student failed" };

            await _unit.PointListRepository.UpdateAsync(pointList);

            pointList.SSI = request.Point;

            pointList.Average = Convert.ToByte(pointList.ExamEntranceScore + pointList.SSI * 0.5);

            if(pointList.Average < 51)
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