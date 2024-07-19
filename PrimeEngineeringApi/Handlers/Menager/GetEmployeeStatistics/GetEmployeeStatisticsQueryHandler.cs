using MediatR;
using PrimeEngineeringApi.Data.Repositories.MenagerRepository;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQueryHandler : IRequestHandler<GetEmployeeStatisticsQuery, GetEmployeeStatisticsQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMenagerRepsitory _menagerRepsitory;

        public GetEmployeeStatisticsQueryHandler(IUserService userService, IMenagerRepsitory menagerRepsitory)
        {
            _userService = userService;
            _menagerRepsitory = menagerRepsitory;
        }
        public async Task<GetEmployeeStatisticsQueryResponse> Handle(GetEmployeeStatisticsQuery request, CancellationToken cancellationToken)
        {
            var menagerId = _userService.GetCurrentUserId();

            var employeeTasks = await _menagerRepsitory.GetTasksForEmployeeAsync(menagerId, request.EmployeeId);

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
