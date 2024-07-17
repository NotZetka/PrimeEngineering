using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data.Repositories.Accounts
{
    public class AccountsRepository : AbstractRepository, IAccountsRepository
    {
        public AccountsRepository(DataContext context) : base(context)
        {
        }

        public async Task<Menager?> GetMenagerByIdAsync(int id)
        {
            return await _context.Menagers.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
