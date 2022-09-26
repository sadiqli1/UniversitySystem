using AutoMapper;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.DTOs.Group;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.Features.Commands.FacultyCommands;
using UniversitySystem.Application.Features.Commands.GroupCommands;
using UniversitySystem.Application.Features.Commands.LessonCommands;
using UniversitySystem.Application.Features.Commands.SectionCommands;
using UniversitySystem.Application.Features.Commands.SectorCommands;
using UniversitySystem.Application.Features.Commands.SpecializationCommand;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Mapping
{
    public class GeneralMap: Profile
    {
        public GeneralMap()
        {
            CreateMap<Sector, SectorGetItemDto>();
            CreateMap<Section, SectionItemDto>();
            CreateMap<Specialization, SpecializationItemDto>();
            CreateMap<Sector, SectorInSpecializationItemDto>();
            CreateMap<Section, SectionInSpecializationItemDto>();
            CreateMap<Faculty, FacultyInSpecializationItemDto>();
            CreateMap<Specialization, SpecializationPostDto>()
                .ReverseMap();
            CreateMap<Sector, SectorCreateCommand>()
                .ReverseMap();
            CreateMap<Section, SectionCreateCommand>()
                .ReverseMap();
            CreateMap<Specialization, SpecializationCreateCommand>()
                .ReverseMap();
            CreateMap<Specialization, SpecializationUpdateCommand>()
                .ReverseMap();
            CreateMap<Faculty, FacultyItemDto>();
            CreateMap<Faculty, FacultyCreateCommand>()
                .ReverseMap();
            CreateMap<Person, PersonRegisterDto>();
            CreateMap<Group, GroupItemDto>();
            CreateMap<Specialization, SpecializationInGroup>();
            CreateMap<Course, CourseInGroup>();
            CreateMap<Teacher, TeacherInGroup>();
            CreateMap<Person, PersonInTeacher>();
            CreateMap<Group, GroupCreateCommand>()
                .ReverseMap();
            CreateMap<Group, GroupUpdateCommand>()
                .ReverseMap();
            CreateMap<Lesson, LessonCreateCommand>()
                .ReverseMap();
            CreateMap<Lesson, LessonUpdateCommand>()
                .ReverseMap();
            CreateMap<LessonCreateCommand, LessonPostDto>()
                .ReverseMap();
            CreateMap<Lesson, LessonItemDto>();
            CreateMap<Group, GroupInLessonItemDto>();
            CreateMap<Course, CourseInLessonItemDto>();
            CreateMap<Teacher, TeacherInLessonItemDto>();
            CreateMap<Person, PersonInTeacherInLessonItemDto>();
        }
    }
}