using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class TyutorRegisterCommandHandler : IRequestHandler<TyutorRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;

        public TyutorRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
        }
        public async Task<PersonRegisterDto> Handle(TyutorRegisterCommand request, CancellationToken cancellationToken)
        {
            Person tyutor = await _usermanager.FindByNameAsync(request.PersonalNumber);

            if (tyutor != null) throw new BadRequestException() { Code = "existed", Description = "there is a tyutor with this personalnumber" } ;

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
                    DutyId = 5,
                    SectionId = request.Teacher.SectionId
                }
            };

            IdentityResult result = await _usermanager.CreateAsync(person, request.Password);

            if (!result.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "Tytor");
            if (!resultRole.Succeeded) throw new NotSucceededException(result.Errors.ToList());

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}