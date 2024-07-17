using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Services
{
    public interface IUserService
    {
        public Task<AppUser> GetCurrentUserAsync();

        public int GetCurrentUserId();
    }
}
