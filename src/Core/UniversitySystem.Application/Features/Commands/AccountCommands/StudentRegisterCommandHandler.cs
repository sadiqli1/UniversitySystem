using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Application.Interfaces.Repository;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class StudentRegisterCommandHandler : IRequestHandler<StudentRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public StudentRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUnitOfWork unit)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
            _unit = unit;
        }
        public async Task<PersonRegisterDto> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
        {
            Person student = await _usermanager.FindByNameAsync(request.PersonalNumber);

            if (student != null) throw new BadRequestException() { Code = "existed", Description = "there is a teacher with this personalnumber" };

            Person person = new()
            {
                Name = request.Name,
                Surname = request.Surname,
                FatherName = request.FatherName,
                UserName = request.PersonalNumber,
                Email = request.Email,
                BirthDay = request.BirthDay,
                RegistrationDate = DateTime.Now,
                PhoneNumber = request.PhoneNumber,

                Student = new()
                {
                    DutyId = 1,
                    Status = request.Student.Status,
                    TuitionDebt = request.Student.TuitionDebt,
                    TuitionfeePayment = request.Student.TuitionfeePayment,
                    Score = request.Student.Score,
                    OrderbyState = request.Student.OrderbyState,
                    RetirebyPresident = request.Student.RetirebyPresident,
                    GroupId = request.Student.GroupId
                }
            };
            

            IdentityResult result = await _usermanager.CreateAsync(person, request.Password);

            if (!result.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "Student");
            if (!resultRole.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            Group group = await _unit.GroupRepository.GetByIdAsync(person.Student.GroupId, "Lessons");

            foreach (Lesson lesson in group.Lessons)
            {
                PointList pointlist = new PointList()
                {
                    StudentId = person.Student.Id,
                    LessonId = lesson.Id,
                };
                await _unit.PointListRepository.AddAsync(pointlist);
            }


            return dto;
        }
    }
}