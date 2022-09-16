using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.DTOs.Sector;

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorUpdateCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SectorUpdateCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
