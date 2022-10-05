using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentGetQueryHandler : IRequestHandler<StudentGetQuery, StudentItemDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly IUnitOfWork _unit;

        public StudentGetQueryHandler(UserManager<Person> userManager, IUnitOfWork unit)
        {
            _usermanager = userManager;
            _unit = unit;
        }
        public async Task<StudentItemDto> Handle(StudentGetQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.Username);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            Student student = await _unit.StudentRepository.GetByExpression(s => s.PersonId == person.Id, "Person", "Group");
            StudentItemDto dto = new StudentItemDto()
            {
                Name = student.Person.Name,
                Surname = student.Person.Surname,
                FatherName = student.Person.FatherName,
                RegistrationDate = student.Person.RegistrationDate,
                BirthDay = student.Person.BirthDay,
                PersonalNumber = student.Person.PersonalNumber,
                Status = student.Status,
                TuitionDebt = student.TuitionDebt,
                TuitionfeePayment = student.TuitionfeePayment,
                Score = student.Score,
                OrderbyState = student.OrderbyState,
                RetirebyPresident = student.RetirebyPresident,
                Group = new GroupInStudentItemDto()
                {
                    Name = student.Group.Name
                }
            };
            return dto;
        }
    }
}