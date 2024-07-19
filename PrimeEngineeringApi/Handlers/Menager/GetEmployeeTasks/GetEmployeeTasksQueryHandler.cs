using MediatR;
using PrimeEngineeringApi.Data.Repositories.MenagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryHandler : IRequestHandler<GetEmployeeTasksQuery, GetEmployeeTasksQueryResult>
    {
        private readonly IUserService _userService;
        private readonly IMenagerRepsitory _menagerRepsitory;

        public GetEmployeeTasksQueryHandler(IUserService userService, IMenagerRepsitory menagerRepsitory)
        {
            _userService = userService;
            _menagerRepsitory = menagerRepsitory;
        }
        public async Task<GetEmployeeTasksQueryResult> Handle(GetEmployeeTasksQuery request, CancellationToken cancellationToken)
        {
            var menagerId = _userService.GetCurrentUserId();

            var employeeTasks = await _menagerRepsitory.GetTasksDtosForEmployeeAsync(menagerId, request.EmployeeId);

            return new() { Tasks = employeeTasks };
        }
    }
}
