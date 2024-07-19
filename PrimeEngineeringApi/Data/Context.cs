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
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Manager>()
                .HasMany(u => u.Employees)
                .WithOne(e => e.Manager)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasMany(x => x.Tasks)
                .WithMany(x => x.Employees);
        }
    }
}
