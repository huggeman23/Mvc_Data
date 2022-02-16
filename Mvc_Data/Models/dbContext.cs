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
 
        public DbSet<CreatePersonViewModel> PersonViewModels { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<CreatePersonViewModel>().HasData(new CreatePersonViewModel() { Id=1, City = "NewYork", Name = "Mathiew", Phone = 220002298 });
        }
        }
}
