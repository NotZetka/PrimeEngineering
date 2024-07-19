using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.ManagerRepository
{
    public interface IManagerRepsitory : IRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesForManagerAsync(int ManagerId);
        Task<IEnumerable<EmployeeTaskDto>> GetTasksDtosForEmployeeAsync(int ManagerId, int employeeId);
        Task<IEnumerable<EmployeeTask>> GetTasksForEmployeeAsync(int ManagerId, int employeeId);

    }
}
