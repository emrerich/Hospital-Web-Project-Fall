using Hospital_Web_Project_Fall.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace Hospital_Web_Project_Fall.Data
{
    public class ApplicationDbContext : DbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Doktor> Doktor { get; set; }


    }
}
