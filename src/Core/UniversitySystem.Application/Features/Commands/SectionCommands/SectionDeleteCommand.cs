using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UniversitySystem.Application.Features.Commands.SectionCommands
{
    public class SectionDeleteCommand: IRequest<int>
    {
        public int Id { get; set; }
        public SectionDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
