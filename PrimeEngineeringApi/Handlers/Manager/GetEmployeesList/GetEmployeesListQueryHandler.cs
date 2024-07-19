using MediatR;
using PrimeEngineeringApi.Data.Repositories.ManagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, GetEmployeesListQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IManagerRepsitory _ManagerRepsitory;

        public GetEmployeesListQueryHandler(IUserService userService, IManagerRepsitory ManagerRepsitory)
        {
            _userService = userService;
            _ManagerRepsitory = ManagerRepsitory;
        }
        public async Task<GetEmployeesListQueryResponse> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var ManagerId = _userService.GetCurrentUserId();

            var employees = await _ManagerRepsitory.GetEmployeesForManagerAsync(ManagerId);

            return new GetEmployeesListQueryResponse()
            {
                Employees = employees,
            };
        }
    }
}
