namespace PrimeEngineeringApi.Data.Repositories.Accounts
{
    public interface IAccountsRepository : IRepository
    {
        public Task<Menager?> GetMenagerByIdAsync(int id);
    }
}
