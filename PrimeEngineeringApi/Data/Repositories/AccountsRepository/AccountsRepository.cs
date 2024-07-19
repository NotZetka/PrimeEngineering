using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data.Repositories.AccountsRepository
{
    public class AccountsRepository : AbstractRepository, IAccountsRepository
    {
        public AccountsRepository(DataContext context) : base(context)
        {
        }

        public async Task<Manager?> GetManagerByIdAsync(int id)
        {
            return await _context.Managers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
