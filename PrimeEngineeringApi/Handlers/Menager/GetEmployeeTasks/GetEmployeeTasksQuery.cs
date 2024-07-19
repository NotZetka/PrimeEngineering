using MediatR;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeTasks
{
    public class GetEmployeeTasksQuery : IRequest<GetEmployeeTasksQueryResult>
    {
        public int EmployeeId { get; set; }
    }
}
