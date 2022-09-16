using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UniversitySystem.Application.DTOs.Sector;

namespace UniversitySystem.Application.Features.Commands.SectorCommands
{
    public class SectorCreateCommand: IRequest<int>
    {
        public string Name { get; set; }
    }
}
