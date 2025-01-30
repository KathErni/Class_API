using Class_API.Model.Entity;

namespace Class_API.Model.Contracts
{
    public record CreateSection
    {
        public string SectionName { get; init; }
        public required string Adviser_LastName { get; init; }
    }

    public record UpdateSection
    {
        public string SectionName { get; init; }
        public required string Adviser_LastName { get; init; }
    }

    public record DeleteSection
    {
        public int Id { get; init; }

    }

    public record SectionDTO
    {
        public int Id { get; set; }
        public required string SectionName { get; set; }
        public required string Adviser_LastName { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
