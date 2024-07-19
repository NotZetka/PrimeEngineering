using MediatR;
using PrimeEngineeringApi.Data.Repositories.ManagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQueryHandler : IRequestHandler<GetEmployeeStatisticsQuery, GetEmployeeStatisticsQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IManagerRepsitory _ManagerRepsitory;

        public GetEmployeeStatisticsQueryHandler(IUserService userService, IManagerRepsitory ManagerRepsitory)
        {
            _userService = userService;
            _ManagerRepsitory = ManagerRepsitory;
        }
        public async Task<GetEmployeeStatisticsQueryResponse> Handle(GetEmployeeStatisticsQuery request, CancellationToken cancellationToken)
        {
            var ManagerId = _userService.GetCurrentUserId();

            var employeeTasks = await _ManagerRepsitory.GetTasksForEmployeeAsync(ManagerId, request.EmployeeId);

            var tasksGrouped = employeeTasks.GroupBy(x => new { x.DateDeadline.Year, x.DateDeadline.Month }).ToList();

            var response = new GetEmployeeStatisticsQueryResponse
            {
                FinishedTasks = employeeTasks.Where(x => x.Finished).Count(),
                UnfinishedTasks = employeeTasks.Where(x => !x.Finished).Count(),
                MonthlyStats = tasksGrouped.Select(x=> 
                    new MonthlyStats(x, x.First().DateDeadline.Year, x.First().DateDeadline.Month))
                    .ToList(),
            };

            return response;
        }
    }
}
