using AutoMapper;
using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.DTOs.Attendance;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Queries.AttendanceQueries
{
    public class LessonScheduleQueryHandler : IRequestHandler<LessonScheduleQuery, List<LessonScheduleDto>>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public LessonScheduleQueryHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<List<LessonScheduleDto>> Handle(LessonScheduleQuery request, CancellationToken cancellationToken)
        {
            List<LessonSchedule> existed = await _unit.LessonScheduleRepository.GetAllAsync(l => l.LessonId == request.lessonId);
            if (existed.Count == 0) throw new BadRequestException() { Code = "not found", Description = "not found"};
            List<LessonScheduleDto> dtos = _mapper.Map<List<LessonScheduleDto>>(existed);
            return dtos;
        }
    }
}