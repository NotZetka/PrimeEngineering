using Microsoft.EntityFrameworkCore;

namespace PrimeEngineeringApi.Data.Repositories.AccountsRepository
{
    public class AccountsRepository : AbstractRepository, IAccountsRepository
    {
        public AccountsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Manager?> GetManagerByIdAsync(int id)
        {
            return await _unitOfWork.Managers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
