namespace PrimeEngineeringApi.Data.Repositories.AccountsRepository
{
    public interface IAccountsRepository : IRepository
    {
        public Task<Menager?> GetMenagerByIdAsync(int id);
    }
}
