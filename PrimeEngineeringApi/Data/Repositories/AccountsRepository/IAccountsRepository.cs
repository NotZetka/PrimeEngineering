namespace PrimeEngineeringApi.Data.Repositories.AccountsRepository
{
    public interface IAccountsRepository : IRepository
    {
        public Task<Manager?> GetManagerByIdAsync(int id);
    }
}
