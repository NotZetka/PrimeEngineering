using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryResponse
    {
        public IEnumerable<EmployeeTaskDto> Tasks { get; set; }
    }
}
