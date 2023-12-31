using Hospital_Web_Project_Fall.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Hospital_Web_Project_Fall.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Poliklinik> Poliklinik { get; set; }
        public DbSet<AnaBilimDali> AnaBilimDali { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }


    }
}
