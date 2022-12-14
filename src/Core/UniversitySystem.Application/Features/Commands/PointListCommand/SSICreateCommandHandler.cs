using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SSICreateCommandHandler : IRequestHandler<SSICreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<Person> _usermanager;

        public SSICreateCommandHandler(IUnitOfWork unit, UserManager<Person> userManager)
        {
            _unit = unit;
            _usermanager = userManager;
        }
        public async Task<int> Handle(SSICreateCommand request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.TeacherUsername);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };

            Teacher teacher = await _unit.TeacherRepository.GetByExpression(t => t.PersonId == person.Id && t.Lessons.Any(x => x.Id == request.LessonId));
            if (teacher == null) throw new BadRequestException() { Code = "relation", Description = "this teacher does not teach this class" };

            PointList pointList = await _unit.PointListRepository.GetByExpression(p => p.StudentId == request.StudentId && p.LessonId == request.LessonId);

            if (pointList == null) return 0;

            if (pointList.AttendancePoint < 75) throw new BadRequestException() { Code = "failed", Description = "this student failed due to truancy" };

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