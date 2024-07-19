using MediatR;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQuery : IRequest<GetEmployeeStatisticsQueryResponse>
    {
        public int EmployeeId { get; set; }
    }
}
