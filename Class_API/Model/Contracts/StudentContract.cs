namespace Class_API.Model.Contracts
{
    public record CreateStudent
    {
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string City { get; init; }
        public required string Em_Contact { get; init; }

        public int SectionId { get; init; }
    }

    public record UpdateStudent {
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string City { get; init; }
        public required string Em_Contact { get; init; }

        public int SectionId { get; init; }
    }
    public record DeleteStudent 
    {
        public int Id { get; init; }   
    }

    public record GetStudent
    {
        public int Id { get; init; }
    }
    public class StudentDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Em_Contact { get; set; }

        public int SectionId { get; set; }
    }
}
