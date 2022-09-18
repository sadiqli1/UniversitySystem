using MediatR;
using UniversitySystem.Application.DTOs.Faculty;

namespace UniversitySystem.Application.Features.Queries.FacultyQueries
{
    public class FacultyGetQuery: IRequest<FacultyItemDto>
    {
        public int Id { get; set; }
        public FacultyGetQuery(int id)
        {
            Id = id;
        }
    }
}
