using MediatR;

namespace UniversitySystem.Application.Features.Commands.LessonCommands
{
    public class LessonUpdateCommand: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Ects { get; set; }
        public int Theory { get; set; }
        public int Practice { get; set; }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public List<int> DayHourIds { get; set; }
    }
}