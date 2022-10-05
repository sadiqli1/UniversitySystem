using AutoMapper;
using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Student;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.StudentQueries
{
    public class StudentEJurnalDetailQueryHandler : IRequestHandler<StudentEJurnalDetailQuery, List<StudentEJurnalDetailDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public StudentEJurnalDetailQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<StudentEJurnalDetailDto>> Handle(StudentEJurnalDetailQuery request, CancellationToken cancellationToken)
        {
            List<LessonSchedule> schedules = await _unit.LessonScheduleRepository.GetAllAsync(l => l.LessonId == request.LessonId, "Attendance");
            if (schedules == null) throw new BadRequestException() { Code = "Not Found", Description = "No such student exists" };
            List<StudentEJurnalDetailDto> dtos = _mapper.Map<List<StudentEJurnalDetailDto>>(schedules);
            //schedules.ForEach(s =>
            //{
            //    dtos.ForEach(d =>
            //    {
            //        d.Status = s.Attendance.Status;
            //    });
            //});
            return dtos;
        }
    }
}