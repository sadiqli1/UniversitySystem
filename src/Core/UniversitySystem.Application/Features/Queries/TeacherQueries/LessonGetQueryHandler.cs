using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.DTOs.Teacher;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.TeacherQueries
{
    public class LessonGetQueryHandler : IRequestHandler<LessonGetQuery, List<TchLessonItemDto>>
    {
        private readonly UserManager<Person> _usermanager;
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonGetQueryHandler(UserManager<Person> userManager, IUnitOfWork unit, IMapper mapper)
        {
            _usermanager = userManager;
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<TchLessonItemDto>> Handle(LessonGetQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.TeacherUsername);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such person exists" };
            Teacher teacher = await _unit.TeacherRepository.GetByExpression(t => t.PersonId == person.Id);
            if (teacher == null) throw new BadRequestException() { Code = "Not Found", Description = "No such teacher exists" };
            List<Lesson> lesson = await _unit.LessonRepository.GetAllAsync(l => l.TeacherId == teacher.Id, "Group", "Course", "Teacher", "Teacher.Person", "LessonDayHours", "LessonDayHours.DayHour", "LessonDayHours.DayHour.Day", "LessonDayHours.DayHour.Hour", "LessonSchedules");
            List<TchLessonItemDto> dtos = _mapper.Map<List<TchLessonItemDto>>(lesson);
            return dtos;
        }
    }
}