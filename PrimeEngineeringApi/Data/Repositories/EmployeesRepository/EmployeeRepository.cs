using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.EmployeesRepository
{
    public class EmployeeRepository : AbstractRepository, IEmployeeRepository
    {
        private readonly IMapper _mapper;

        public EmployeeRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public void AddTask(EmployeeTask task, int authorId)
        {
            var author = _unitOfWork.Employees.FirstOrDefault(x => x.Id == authorId);

            task.AuthorId = authorId;
            task.Employees.Add(author);

            _unitOfWork.Tasks.Add(task);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAvailabileEmployeesForTask(int userId, int taskId)
        {
            var task = await _unitOfWork.Tasks.Include(x=>x.Employees).FirstOrDefaultAsync(x=>x.Id == taskId);
            if (task != null &&
                task.Employees.Select(x => x.Id).Contains(userId))
            {
                return await _unitOfWork.Employees
                    .Where(x=>
                        !x.Tasks.Select(x=>x.Id)
                        .Contains(taskId))
                    .Select(x=>_mapper.Map<EmployeeDto>(x))
                    .ToListAsync();
            }
            return new List<EmployeeDto>();
        }

        public async Task<EmployeeTask> GetTask(int taskId)
        {
            return await _unitOfWork.Tasks
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id == taskId);
        }

        public async Task<IEnumerable<EmployeeTaskDto>> GetTasks(int userId)
        {
            return await _unitOfWork.Tasks
                .Where(x => x.Employees
                    .Select(e => e.Id)
                    .Contains(userId))
                .ProjectTo<EmployeeTaskDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
