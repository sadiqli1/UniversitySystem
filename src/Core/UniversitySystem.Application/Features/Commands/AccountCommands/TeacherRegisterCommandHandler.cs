
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class TeacherRegisterCommandHandler : IRequestHandler<TeacherRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;

        public TeacherRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
        }
        public async Task<PersonRegisterDto> Handle(TeacherRegisterCommand request, CancellationToken cancellationToken)
        {
            Person teacher = await _usermanager.FindByNameAsync(request.PersonalNumber);

            if (teacher != null) throw new BadRequestException() { Code = "existed", Description = "there is a teacher with this personalnumber" };

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

                Teacher = new()
                {
                    DutyId = 2,
                    SectionId = request.Teacher.SectionId
                }
            };

            IdentityResult result = await _usermanager.CreateAsync(person, request.Password);

            if (!result.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "Teacher");
            if(!resultRole.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}