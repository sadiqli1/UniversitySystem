using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class StudentRegisterCommandHandler : IRequestHandler<StudentRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;

        public StudentRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
        }
        public async Task<PersonRegisterDto> Handle(StudentRegisterCommand request, CancellationToken cancellationToken)
        {
            Person student = await _usermanager.FindByNameAsync(request.PersonalNumber);

            if (student != null) return null;

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

            if (!result.Succeeded) return null;

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "Student");
            if (!resultRole.Succeeded) return null;

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}