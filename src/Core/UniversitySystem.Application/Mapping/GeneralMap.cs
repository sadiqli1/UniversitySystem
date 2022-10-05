using AutoMapper;
using UniversitySystem.Application.DTOs.Account;
using UniversitySystem.Application.DTOs.Attendance;
using UniversitySystem.Application.DTOs.Faculty;
using UniversitySystem.Application.DTOs.Group;
using UniversitySystem.Application.DTOs.Lesson;
using UniversitySystem.Application.DTOs.Section;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.DTOs.Specialization;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.DTOs.Teacher;
using UniversitySystem.Application.Features.Commands.AttendanceCommands;
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
            CreateMap<Teacher, TeacherInLessonItemDto>();
            CreateMap<Person, PersonInTeacherInLessonItemDto>();
            CreateMap<Group, GroupInLessonItemDto>();
            CreateMap<Course, CourseInLessonItemDto>();
            CreateMap<LessonDayHour, LessonDayHourInDto>();
            CreateMap<DayHour, DayHourInLessonDayHourInDto>();
            CreateMap<Day, DayInDto>();
            CreateMap<Hour, HourInDto>();
            CreateMap<Attendance, AttendanceCreateCommand>()
                .ReverseMap();
            CreateMap<LessonSchedule, LessonScheduleInLessonItemDto>();
            CreateMap<AttendanceUpdateItemDto, AttendanceUpdateCommand>();
            CreateMap<PointList, PoinListInLessonItemDto>();
            CreateMap<PointList, StudentGradesDto>();
            CreateMap<PointList, StudentEJurnalDto>();
            CreateMap<Lesson, LessonInStudentEJurnalDto>();
            CreateMap<Teacher, TeacherLessonInStudentEJurnalDto>();
            CreateMap<Person, PersonInTeacherLessonInStudentEJurnalDto>();
            CreateMap<LessonSchedule, StudentEJurnalDetailDto>();
            CreateMap<Attendance, AttendanceInStudentEJurnalDetailDto>();
            CreateMap<Teacher, TeacherItemDto>();
            CreateMap<Person, PersonInTeacherItemDto>();
            CreateMap<Section, SectionInTeacherItemDto>();
            CreateMap<Lesson, TchLessonItemDto>();
            CreateMap<Group, GroupInTechLessonItemDto>();
            CreateMap<Course, CourseInTechLessonItemDto>();
            CreateMap<LessonDayHour, TechLessonDayHourInDto>();
            CreateMap<LessonSchedule, LessonScheduleInTechLessonItemDto>();
            CreateMap<PointList, PoinListIntechLessonItemDto>();
            CreateMap<DayHour, DayHourInTechLessonDayHourInDto>();
            CreateMap<Day, TechDayInDto>();
            CreateMap<Hour, TechHourInDto>();
            CreateMap<DayHour, DaysGetDto>();
            CreateMap<Day, DayInDaysGetDto>();
            CreateMap<Hour, HourInDaysGetDto>();
            CreateMap<LessonSchedule, LessonScheduleDto>();
        }
    }
}