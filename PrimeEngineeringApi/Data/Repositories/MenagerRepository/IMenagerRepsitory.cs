using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.MenagerRepository
{
    public interface IMenagerRepsitory : IRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesForMenagerAsync(int menagerId);
        Task<IEnumerable<EmployeeTaskDto>> GetTasksDtosForEmployeeAsync(int menagerId, int employeeId);
        Task<IEnumerable<EmployeeTask>> GetTasksForEmployeeAsync(int menagerId, int employeeId);

    }
}
