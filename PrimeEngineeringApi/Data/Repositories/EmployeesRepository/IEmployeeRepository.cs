using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.EmployeesRepository
{
    public interface IEmployeeRepository : IRepository
    {
        public void AddTask(EmployeeTask task, int authorId);

        public Task<IEnumerable<EmployeeTaskDto>> GetTasks(int userId);

        public Task<EmployeeTask> GetTask(int taskId);
        public Task<IEnumerable<EmployeeDto>> GetAvailabileEmployeesForTask(int userId, int taskId);
    }
}
