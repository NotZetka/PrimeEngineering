using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Utilities.Extensions;

namespace PrimeEngineeringApi.Services
{
    public class UserService : IUserService
    {
        private readonly HttpContext _httpContext;
        private readonly DataContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        public async Task<Employee> GetCurrentEmployee()
        {
            return await GetEmployeeById(GetCurrentUserId());
        }

        public int GetCurrentUserId()
        {
            var user = _httpContext.User;

            return user.GetUserId();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
