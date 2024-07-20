using AutoMapper;
using MediatR;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Data.Repositories.EmployeesRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Employees.CreateTask
{
    public class CreateTaskQueryHandler : IRequestHandler<CreateTaskQuery, CreateTaskQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly DataContext _context;

        public CreateTaskQueryHandler(IUserService userService, IMapper mapper, IEmployeeRepository employeeRepository, DataContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _context = context;
        }
        public async Task<CreateTaskQueryResponse> Handle(CreateTaskQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            var task = _mapper.Map<EmployeeTask>(request);
            task.DateCreated = DateTime.UtcNow;

            _employeeRepository.AddTask(task, userId);

            await _employeeRepository.SaveChangesAsync();

            return new();
        }
    }
}
