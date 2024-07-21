using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data.Repositories
{
    public interface IUnitOfWork
    {
        DataContext Context { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Manager> Managers { get; }
        DbSet<EmployeeTask> Tasks { get; }
    }
}