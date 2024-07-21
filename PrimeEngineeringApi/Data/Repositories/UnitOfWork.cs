using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public DataContext Context { get => _context; }
        public DbSet<Employee> Employees { get => _context.Employees; }
        public DbSet<Manager> Managers { get => _context.Managers; }
        public DbSet<EmployeeTask> Tasks { get => _context.Tasks; }
    }
}
