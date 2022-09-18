
using MediatR;
using UniversitySystem.Application.DTOs.Faculty;

namespace UniversitySystem.Application.Features.Queries.FacultyQueries
{
    public class FacultyGetAllQuery: IRequest<List<FacultyItemDto>>
    {
    }
}