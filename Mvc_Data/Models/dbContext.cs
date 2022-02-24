using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvc_Data.Models;
using System;
using System.Threading.Tasks;


namespace Mvc_Data.Models
{
    public class dbContext: IdentityDbContext<AppUser>
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
        public DbSet<AppUser> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>().HasKey(pl => new {pl.Id,pl.LanguageID});

            modelBuilder.Entity<Countery>().HasData(new Countery() { CounteryName = "USA" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, Name = "Montana", CounteryName="USA"});
            modelBuilder.Entity<Person>().HasData(new Person() { Id=1, CityID = 1, Name = "Mathiew", Phone = 220002298 });
            modelBuilder.Entity<Language>().HasData(new Language() { LanguageID = 1, LanguageName = "Engelska" });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage() { LanguageID = 1, Id = 1, });


            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"

            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"

            });

            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Admin",
                LastName = "Adminsson",
                Age = 294
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

        }
        }
}
