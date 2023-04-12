using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HallOfFame.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Person> Persons { get; set; }
        
        public ApplicationContext(DbContextOptions options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasKey(s => s.Name);


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder
                .Entity<Person>()
                .Property(p => p.Id)
                .HasConversion<int>();

            modelBuilder
                .Entity<Skill>()
                .Property(s => s.Level)
                .HasConversion<int>();
            modelBuilder
                .Entity<Skill>()
                .Property(s => s.PersonId)
                .HasConversion<int>();
        }
    }
}
