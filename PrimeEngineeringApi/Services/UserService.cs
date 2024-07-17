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

        public async Task<AppUser> GetCurrentUserAsync()
        {
            var userid = GetCurrentUserId();

            return await _context.Users.FirstOrDefaultAsync(x => x.Id == userid);
        }

        public int GetCurrentUserId()
        {
            var user = _httpContext.User;

            return user.GetUserId();
        }
    }
}
