using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AccountCommands
{
    public class LibrarianRegisterCommandHandler : IRequestHandler<LibrarianRegisterCommand, PersonRegisterDto>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public LibrarianRegisterCommandHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IUnitOfWork unit)
        {
            _usermanager = userManager;
            _rolemanager = roleManager;
            _mapper = mapper;
            _unit = unit;
        }
        public async Task<PersonRegisterDto> Handle(LibrarianRegisterCommand request, CancellationToken cancellationToken)
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

                Librarian = new()
                {
                    DutyId = 4,
                    LibraryId = request.Librarian.LibraryId
                }
            };

            IdentityResult result = await _usermanager.CreateAsync(person, request.Password);

            if (!result.Succeeded) return null;

            IdentityResult resultRole = await _usermanager.AddToRoleAsync(person, "Librarian");
            if (!resultRole.Succeeded) return null;

            PersonRegisterDto dto = _mapper.Map<PersonRegisterDto>(person);
            dto.PersonalNumber = person.UserName;

            return dto;
        }
    }
}
