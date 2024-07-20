using MediatR;
using PrimeEngineeringApi.Data.Repositories.EmployeesRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Employees.GetNoContributorsforTask
{
    public class GetNoContributorsforTaskQueryHandler : IRequestHandler<GetNoContributorsforTaskQuery, GetNoContributorsforTaskQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeeRepository _employeeRepository;

        public GetNoContributorsforTaskQueryHandler(IUserService userService, IEmployeeRepository employeeRepository)
        {
            _userService = userService;
            _employeeRepository = employeeRepository;
        }
        public async Task<GetNoContributorsforTaskQueryResponse> Handle(GetNoContributorsforTaskQuery request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            var availabileEmployees = await _employeeRepository.GetAvailabileEmployeesForTask(userId, request.TaskId);

            return new() { Employees = availabileEmployees };
        }
    }
}
