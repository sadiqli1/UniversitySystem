using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
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

            if (edu != null) throw new BadRequestException() { Code = "existed", Description = "there is a edu with this personalnumber" };

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

            if (!result.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "EducationDepartment");
            if (!resultRole.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}
