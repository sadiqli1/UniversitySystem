namespace UniversitySystem.Application.CustomException
{
    public class RelationException: Exception
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
