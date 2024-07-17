using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppUserRole, int>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Menager> Menagers { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Menager>()
                .HasMany(u => u.Employees)
                .WithOne(e => e.Menager)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
