using MediatR;
using PrimeEngineeringApi.Data.Repositories.Employees;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Employees.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, GetTasksQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeeRepository _employeeRepository;

        public GetTasksQueryHandler(IUserService userService, IEmployeeRepository employeeRepository)
        {
            _userService = userService;
            _employeeRepository = employeeRepository;
        }
        public async Task<GetTasksQueryResponse> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            var tasks = await _employeeRepository.GetTasks(userId);

            return new() { Tasks = tasks };
        }
    }
}
