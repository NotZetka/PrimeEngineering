using MediatR;
using PrimeEngineeringApi.Data.Repositories.MenagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, GetEmployeesListQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMenagerRepsitory _menagerRepsitory;

        public GetEmployeesListQueryHandler(IUserService userService, IMenagerRepsitory menagerRepsitory)
        {
            _userService = userService;
            _menagerRepsitory = menagerRepsitory;
        }
        public async Task<GetEmployeesListQueryResponse> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var menagerId = _userService.GetCurrentUserId();

            var employees = await _menagerRepsitory.GetEmployeesForMenagerAsync(menagerId);

            return new GetEmployeesListQueryResponse()
            {
                Employees = employees,
            };
        }
    }
}
