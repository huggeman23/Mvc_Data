using Microsoft.EntityFrameworkCore;
using Mvc_Data.Models;
using System.Threading.Tasks;


namespace Mvc_Data
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
            //Database.SetInitializer(new dbInitialiser());
             
        }
        
        public DbSet<Countery> countery { get; set; }
        public DbSet<City> city { get; set; } 
        public DbSet<Person> peapole { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countery>().HasData(new Countery() { CounteryName = "USA" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, Name = "Montana", CounteryName="USA"});
            modelBuilder.Entity<Person>().HasData(new Person() { Id=1, CityID = 1, Name = "Mathiew", Phone = 220002298 });
            
        }
        }
}
