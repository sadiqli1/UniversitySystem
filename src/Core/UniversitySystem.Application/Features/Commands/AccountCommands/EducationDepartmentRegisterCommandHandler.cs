using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class EducationDepartmentRegisterCommandHandler : IRequestHandler<EducationDepartmentRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public EducationDepartmentRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUnitOfWork unit)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
            _unit = unit;
        }
        public async Task<PersonRegisterDto> Handle(EducationDepartmentRegisterCommand request, CancellationToken cancellationToken)
        {
            Person edu = await _usermanager.FindByNameAsync(request.PersonalNumber);

            if (edu != null) return null;

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

                EducationDepartment = new()
                {
                    DutyId = 3
                }
            };

            IdentityResult result = await _usermanager.CreateAsync(person, request.Password);

            if (!result.Succeeded) return null;

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "EducationDepartment");
            if (!resultRole.Succeeded) return null;

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}
