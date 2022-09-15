using AutoMapper;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Mapping
{
    public class GeneralMap: Profile
    {
        public GeneralMap()
        {
            CreateMap<Sector, SectorGetItemDto>();
            CreateMap<Sector, SectorPostDto>()
                .ReverseMap();
            CreateMap<Section, SectionItemDto>();
            CreateMap<Section, SectionPostDto>()
                .ReverseMap();
            CreateMap<Specialization, SpecializationItemDto>();
            CreateMap<Sector, SectorInSpecializationItemDto>();
            CreateMap<Section, SectionInSpecializationItemDto>();
            CreateMap<Faculty, FacultyInSpecializationItemDto>();
            CreateMap<Specialization, SpecializationPostDto>()
                .ReverseMap();
        }
    }
}
