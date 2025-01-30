using Class_API.Model.Contracts;

namespace Class_API.Model.Entity
{
    public class Section
    {
        public int Id { get; set; }
        public required string SectionName { get; set; }
        public required string Adviser_LastName { get; set; }

        //Shows all the students within the named section
        public ICollection<Student> Students { get; set; }
    }
}
