using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Services
{
    public interface IUserService
    {
        public int GetCurrentUserId();

        public Task<Employee> GetCurrentEmployee();
        public Task<Employee> GetEmployeeById(int id);
    }
}
