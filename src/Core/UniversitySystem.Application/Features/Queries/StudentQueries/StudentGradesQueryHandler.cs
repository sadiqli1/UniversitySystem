using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentGradesQueryHandler : IRequestHandler<StudentGradesQuery, List<StudentGradesDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _usermanager;

        public StudentGradesQueryHandler(IUnitOfWork unit, IMapper mapper, UserManager<Person> userManager)
        {
            _unit = unit;
            _mapper = mapper;
            _usermanager = userManager;
        }
        public async Task<List<StudentGradesDto>> Handle(StudentGradesQuery request, CancellationToken cancellationToken)
        {
            Person person = await _usermanager.FindByNameAsync(request.Username);
            if (person == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            Student student = await _unit.StudentRepository.GetByExpression(s => s.PersonId == person.Id, "Person", "Group");
            List<PointList> pointLists = await _unit.PointListRepository.GetAllAsync(p => p.StudentId == student.Id, "Lesson", "Lesson.Teacher", "Lesson.Teacher.Person");
            if (pointLists == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            //List<StudentGradesDto> dtos = _mapper.Map<List<StudentGradesDto>>(pointLists);
            List<StudentGradesDto> dtos = new List<StudentGradesDto>();
            StudentGradesDto dto = new StudentGradesDto();
            pointLists.ForEach(point =>
            {
                dto.SDF1 = point.SDF1;
                dto.SDF2 = point.SDF2;
                dto.SDF3 = point.SDF3;
                dto.TSI = point.TSI;
                dto.AttendancePoint = point.AttendancePoint;
                dto.AttendanceCount = point.AttendanceCount;
                dto.SSI = point.SSI;
                dto.AdditionalExam = point.AdditionalExam;
                dto.ReExam = point.ReExam;
                dto.Average = point.Average;
                dto.ExamEntranceScore = point.ExamEntranceScore;
                dto.Failed = point.Failed;
                dto.Lesson = new LessonInStudentGradesDto()
                {
                    Name = point.Lesson.Name,
                    Code = point.Lesson.Code,
                    Ects = point.Lesson.Ects,
                    Theory = point.Lesson.Theory,
                    Practice = point.Lesson.Practice,
                    LessonHour = point.Lesson.LessonHour,
                    Teacher = new TeacherInLessonInStudentGradesDto()
                    {
                        Person = new PersonTeacherInLessonInStudentGradesDto()
                        {
                            Name = point.Lesson.Teacher.Person.Name,
                            Surname = point.Lesson.Teacher.Person.Surname
                        },
                    },
                };
                dtos.Add(dto);
            });
            return dtos;
        }
    }
}