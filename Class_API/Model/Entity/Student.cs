namespace Class_API.Model.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string Em_Contact { get; set; }
        public int SectionId { get; set; }

        public Section Section { get; set; }


    }
}
