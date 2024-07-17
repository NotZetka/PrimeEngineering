using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.Employees
{
    public interface IEmployeeRepository : IRepository
    {
        public void AddTask(EmployeeTask task, int authorId);

        public Task<IEnumerable<EmployeeTaskDto>> GetTasks(int userId);

        public Task<EmployeeTask> GetTask(int taskId);
    }
}
