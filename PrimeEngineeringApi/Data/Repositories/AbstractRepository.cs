namespace PrimeEngineeringApi.Data.Repositories
{
    public abstract class AbstractRepository : IRepository
    {
        protected readonly DataContext _context;

        protected AbstractRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
