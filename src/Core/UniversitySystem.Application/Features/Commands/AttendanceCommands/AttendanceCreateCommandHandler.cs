﻿using AutoMapper;
using MediatR;
using UniversitySystem.Application.CustomException;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceCreateCommandHandler : IRequestHandler<AttendanceCreateCommand, int>
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public AttendanceCreateCommandHandler(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<int> Handle(AttendanceCreateCommand request, CancellationToken cancellationToken)
        {
            List<Attendance> attendances = await _unit.AttendanceRepository
                .GetAllAsync(a => a.StudentId == request.StudentId && a.LessonScheduleId == request.LessonScheduleId && a.LessonId == request.LessonId);
            if(attendances.Count != 0) return -3;

            LessonSchedule schedule = await _unit.LessonScheduleRepository.GetByIdAsync(request.LessonScheduleId);
            Lesson lesson = await _unit.LessonRepository.GetByIdAsync(request.LessonId);
            Student student = await _unit.StudentRepository.GetByIdAsync(request.StudentId);
            LessonSchedule lessonSchedule = await _unit.LessonScheduleRepository.GetByIdAsync(request.LessonScheduleId);

            if (schedule == null || lesson == null || student == null) throw new RelationException(){ Code = "relation", Description = "there is no such relation"};

            if (lessonSchedule.LessonId != request.LessonId) return -1;

            if(lessonSchedule.Date > DateTime.Now) return -2;

            if (student.GroupId != lesson.GroupId) return 0;

            Attendance attendance = _mapper.Map<Attendance>(request);
            await _unit.AttendanceRepository.AddAsync(attendance);

            List<PointList> points = await _unit.PointListRepository.GetAllAsync(p => p.StudentId == attendance.StudentId && p.LessonId == attendance.LessonId, "Lesson");
            foreach (PointList point in points)
            {
                await _unit.PointListRepository.UpdateAsync(point);
                if(attendance.Status == false)
                {
                    point.AttendanceCount += 1;
                    int a = 100 / point.Lesson.LessonHour;
                    point.AttendancePoint -= Convert.ToByte(a);
                }
                await _unit.SaveChangesAsync();
            }

            return attendance.Id;
        }
    }
}