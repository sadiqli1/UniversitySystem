using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.PointListCommand
{
    public class SDF2CrerateCommandHandler : IRequestHandler<SDF2CreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<Person> _usermanager;

        public SDF2CrerateCommandHandler(IUnitOfWork unit, UserManager<Person> userManager)
        {
            _unit = unit;
            _usermanager = userManager;
        }
        public async Task<int> Handle(SDF2CreateCommand request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.TeacherUsername);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };

            Teacher teacher = await _unit.TeacherRepository.GetByExpression(t => t.PersonId == person.Id && t.Lessons.Any(x => x.Id == request.LessonId));
            if (teacher == null) throw new BadRequestException() { Code = "relation", Description = "this teacher does not teach this class" };

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