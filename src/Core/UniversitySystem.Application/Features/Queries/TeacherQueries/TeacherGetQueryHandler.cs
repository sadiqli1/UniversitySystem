using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Teacher;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.TeacherQueries
{
    public class TeacherGetQueryHandler : IRequestHandler<TeacherGetQuery, TeacherItemDto>
    {
        private readonly IUnitOfWork _unit;
        private readonly UserManager<Person> _usermanager;
        private readonly IMapper _mapper;

        public TeacherGetQueryHandler(IUnitOfWork unit, UserManager<Person> userManager, IMapper mapper)
        {
            _unit = unit;
            _usermanager = userManager;
            _mapper = mapper;
        }
        public async Task<TeacherItemDto> Handle(TeacherGetQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.UserName);
            if(person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            Teacher teacher = await _unit.TeacherRepository.GetByExpression(t => t.PersonId == person.Id, "Section", "Person");
            
            TeacherItemDto dto = _mapper.Map<TeacherItemDto>(teacher);
            dto.Person.PersonalNumber = person.UserName;
            return dto;
        }
    }
}