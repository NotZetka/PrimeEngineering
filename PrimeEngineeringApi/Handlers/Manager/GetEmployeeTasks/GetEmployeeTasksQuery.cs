using MediatR;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQuery : IRequest<GetEmployeeTasksQueryResult>
    {
        public int EmployeeId { get; set; }
    }
}
