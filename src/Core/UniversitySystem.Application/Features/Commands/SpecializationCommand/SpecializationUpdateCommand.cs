using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UniversitySystem.Application.Features.Commands.SpecializationCommand
{
    public class SpecializationUpdateCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public byte Duration { get; set; }
        public int SectorId { get; set; }
        public int SectionId { get; set; }
        public int FacultyId { get; set; }
        public SpecializationUpdateCommand(int id)
        {
            Id = id;
        }
    }
}
