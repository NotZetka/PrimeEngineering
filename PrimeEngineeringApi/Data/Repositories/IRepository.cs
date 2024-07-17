namespace PrimeEngineeringApi.Data.Repositories
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync();
    }
}
