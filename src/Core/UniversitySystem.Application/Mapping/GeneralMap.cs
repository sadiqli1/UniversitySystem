using AutoMapper;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.Features.Commands.FacultyCommands;
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
        }
    }
}
