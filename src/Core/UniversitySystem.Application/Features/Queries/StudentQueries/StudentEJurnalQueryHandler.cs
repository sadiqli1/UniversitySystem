using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentEJurnalQueryHandler : IRequestHandler<StudentEJurnalQuery, List<StudentEJurnalDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _usermanager;

        public StudentEJurnalQueryHandler(IUnitOfWork unit, IMapper mapper, UserManager<Person> userManager)
        {
            _unit = unit;
            _mapper = mapper;
            _usermanager = userManager;
        }
        public async Task<List<StudentEJurnalDto>> Handle(StudentEJurnalQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.Username);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            Student student = await _unit.StudentRepository.GetByExpression(s => s.PersonId == person.Id, "PointLists", "PointLists.Lesson", "PointLists.Lesson.Teacher", "PointLists.Lesson.Teacher.Person");
            if (student == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            List<StudentEJurnalDto> dtos = _mapper.Map<List<StudentEJurnalDto>>(student.PointLists);
            dtos.ForEach(d =>
            {
                student.PointLists.ForEach(p =>{
                    d.Lesson.AttendanceLimit = (byte)(p.Lesson.LessonHour * 0.25);
                    d.Lesson.QbCount = p.AttendanceCount;
                });
            });
            return dtos;
        }
    }
}