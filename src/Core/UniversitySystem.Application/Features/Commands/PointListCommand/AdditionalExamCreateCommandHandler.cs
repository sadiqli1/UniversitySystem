using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class AdditionalExamCreateCommandHandler : IRequestHandler<AdditionalExamCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public AdditionalExamCreateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(AdditionalExamCreateCommand request, CancellationToken cancellationToken)
        {
            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == request.StudentId && p.LessonId == request.LessonId);

            if (pointList == null) return 0;

            if (pointList.Failed == false) throw new BadRequestException() { Code = "Not Failing", Description = "this student is not failing" };

            await _unit.PointListRepository.UpdateAsync(pointList);

            pointList.AdditionalExam = request.Point;

            pointList.Average = Convert.ToByte(pointList.ExamEntranceScore + pointList.AdditionalExam * 0.5);

            if (pointList.Average < 51)
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