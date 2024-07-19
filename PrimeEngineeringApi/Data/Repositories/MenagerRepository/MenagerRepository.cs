
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PrimeEngineeringApi.Data.Dtos;
using System.Collections.Generic;

namespace PrimeEngineeringApi.Data.Repositories.MenagerRepository
{
    public class MenagerRepository : AbstractRepository, IMenagerRepsitory
    {
        private readonly IMapper _mapper;

        public MenagerRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesForMenagerAsync(int menagerId)
        {
            return await _context.Employees
                .Where(x => x.MenagerId == menagerId)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeTaskDto>> GetTasksDtosForEmployeeAsync(int menagerId, int employeeId)
        {
            return await _context.Employees
                .Where(x => x.Id == employeeId && x.MenagerId == menagerId)
                .SelectMany(x => x.Tasks)
                .Select(x=>_mapper.Map<EmployeeTaskDto>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeTask>> GetTasksForEmployeeAsync(int menagerId, int employeeId)
        {
            return await _context.Employees
                .Where(x => x.Id == employeeId && x.MenagerId == menagerId)
                .Select(x => x.Tasks)
                .FirstOrDefaultAsync();
        }
    }
}
