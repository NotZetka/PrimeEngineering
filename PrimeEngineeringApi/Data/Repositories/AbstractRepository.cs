namespace PrimeEngineeringApi.Data.Repositories
{
    public abstract class AbstractRepository : IRepository
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected AbstractRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.Context.SaveChangesAsync();
        }
    }
}
