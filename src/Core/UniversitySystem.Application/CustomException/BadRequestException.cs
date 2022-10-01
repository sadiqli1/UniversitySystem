namespace UniversitySystem.Application.CustomException
{
    public class BadRequestException: Exception
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
