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
        public DbSet<Language> language { get; set; }
        public DbSet<PersonLanguage> personlanguage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new {pl.Id,pl.LanguageID});

            modelBuilder.Entity<Countery>().HasData(new Countery() { CounteryName = "USA" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, Name = "Montana", CounteryName="USA"});
            modelBuilder.Entity<Person>().HasData(new Person() { Id=1, CityID = 1, Name = "Mathiew", Phone = 220002298 });
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageID = 1, LanguageName = "Engelska" });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage() { LanguageID = 1, Id = 1, });
            
        }
        }
}
