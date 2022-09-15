
namespace UniversitySystem.Application.DTOs.Specialization
{
    public class SpecializationItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public byte Duration { get; set; }
        public SectorInSpecializationItemDto Sector { get; set; }
        public SectionInSpecializationItemDto Section { get; set; }
        public FacultyInSpecializationItemDto Faculty { get; set; }
    }
    public class SectorInSpecializationItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SectionInSpecializationItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class FacultyInSpecializationItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
