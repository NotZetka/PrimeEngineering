using MediatR;
using PrimeEngineeringApi.Data.Repositories.ManagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryHandler : IRequestHandler<GetEmployeeTasksQuery, GetEmployeeTasksQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IManagerRepsitory _ManagerRepsitory;

        public GetEmployeeTasksQueryHandler(IUserService userService, IManagerRepsitory ManagerRepsitory)
        {
            _userService = userService;
            _ManagerRepsitory = ManagerRepsitory;
        }
        public async Task<GetEmployeeTasksQueryResponse> Handle(GetEmployeeTasksQuery request, CancellationToken cancellationToken)
        {
            var ManagerId = _userService.GetCurrentUserId();

            var employeeTasks = await _ManagerRepsitory.GetTasksDtosForEmployeeAsync(ManagerId, request.EmployeeId);

            return new() { Tasks = employeeTasks };
        }
    }
}
