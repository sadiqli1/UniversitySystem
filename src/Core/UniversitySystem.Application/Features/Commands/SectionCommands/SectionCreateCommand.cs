using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UniversitySystem.Application.Features.Commands.SectionCommands
{
    public class SectionCreateCommand: IRequest<SectionCreateCommand>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
