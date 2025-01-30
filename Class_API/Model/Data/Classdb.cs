using Class_API.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Class_API.Model.Data
{
    public class Classdb : DbContext
    {
        public Classdb(DbContextOptions<Classdb> options) : base(options) {
        }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
