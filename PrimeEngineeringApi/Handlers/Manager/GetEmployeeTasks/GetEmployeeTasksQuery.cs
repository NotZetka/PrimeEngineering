using MediatR;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQuery : IRequest<GetEmployeeTasksQueryResponse>
    {
        public int EmployeeId { get; set; }
    }
}
