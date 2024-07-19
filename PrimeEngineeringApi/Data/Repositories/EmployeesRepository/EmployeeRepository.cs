using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Data.Repositories.EmployeesRepository
{
    public class EmployeeRepository : AbstractRepository, IEmployeeRepository
    {
        private readonly IMapper _mapper;

        public EmployeeRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void AddTask(EmployeeTask task, int authorId)
        {
            var author = _context.Employees.FirstOrDefault(x => x.Id == authorId);

            task.AuthorId = authorId;
            task.Employees.Add(author);

            _context.Tasks.Add(task);
        }

        public async Task<EmployeeTask> GetTask(int taskId)
        {
            return await _context.Tasks
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id == taskId);
        }

        public async Task<IEnumerable<EmployeeTaskDto>> GetTasks(int userId)
        {
            return await _context.Tasks
                .Where(x => x.Employees
                    .Select(e => e.Id)
                    .Contains(userId))
                .ProjectTo<EmployeeTaskDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
