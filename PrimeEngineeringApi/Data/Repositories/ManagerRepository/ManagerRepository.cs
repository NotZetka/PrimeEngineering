
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data.Dtos;
using System.Collections.Generic;

namespace PrimeEngineeringApi.Data.Repositories.ManagerRepository
{
    public class ManagerRepository : AbstractRepository, IManagerRepsitory
    {
        private readonly IMapper _mapper;

        public ManagerRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesForManagerAsync(int ManagerId)
        {
            return await _context.Employees
                .Where(x => x.ManagerId == ManagerId)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeTaskDto>> GetTasksDtosForEmployeeAsync(int ManagerId, int employeeId)
        {
            return await _context.Employees
                .Where(x => x.Id == employeeId && x.ManagerId == ManagerId)
                .SelectMany(x => x.Tasks)
                .Select(x=>_mapper.Map<EmployeeTaskDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeTask>> GetTasksForEmployeeAsync(int ManagerId, int employeeId)
        {
            return await _context.Employees
                .Where(x => x.Id == employeeId && x.ManagerId == ManagerId)
                .Select(x => x.Tasks)
                .FirstOrDefaultAsync();
        }
    }
}
