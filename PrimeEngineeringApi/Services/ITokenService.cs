using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
