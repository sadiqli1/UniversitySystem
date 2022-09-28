using MediatR;
using UniversitySystem.Application.Interfaces;
using UniversitySystem.Domain.Entities;

namespace UniversitySystem.Application.Features.Commands.AttendanceCommands
{
    public class AttendanceUpdateCommandHandler : IRequestHandler<AttendanceUpdateCommand, int>
    {
        private readonly IUnitOfWork _unit;

        public AttendanceUpdateCommandHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<int> Handle(AttendanceUpdateCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = await _unit.AttendanceRepository.GetByIdAsync(request.Id);
            if (attendance == null) return 0;
            await _unit.AttendanceRepository.UpdateAsync(attendance);
            attendance.Status = request.Status;
            await _unit.SaveChangesAsync();
            return attendance.Id;
        }
    }
}