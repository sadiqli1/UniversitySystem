using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentCourseScheduleQueryHandler : IRequestHandler<StudentCourseScheduleQuery, List<StudentCourseScheduleDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<Person> _usermanager;

        public StudentCourseScheduleQueryHandler(IUnitOfWork unit, UserManager<Person> userManager)
        {
            _unit = unit;
            _usermanager = userManager;
        }
        public async Task<List<StudentCourseScheduleDto>> Handle(StudentCourseScheduleQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.Username);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            Student student = await _unit.StudentRepository.GetByExpression(s => s.PersonId == person.Id, "Group", "Group.Lessons", "Group.Lessons.LessonDayHours", "Group.Lessons.LessonDayHours.DayHour", "Group.Lessons.LessonDayHours.DayHour.Day", "Group.Lessons.LessonDayHours.DayHour", "Group.Lessons.LessonDayHours.DayHour.Hour");
            if (student == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };

            List<StudentCourseScheduleDto> dtos = new List<StudentCourseScheduleDto>();

            student.Group.Lessons.ForEach(l =>
            {
                l.LessonDayHours.ForEach(d =>
                {
                    string datestr = (d.DayHour.Day.Name +" " + d.DayHour.Hour.Name);
                    StudentCourseScheduleDto dto = new StudentCourseScheduleDto()
                    {
                        Name = l.Name,
                        Code = l.Code,
                        Date = datestr
                    };
                    dtos.Add(dto);
                });
            });
            return dtos;
        }
    }
}