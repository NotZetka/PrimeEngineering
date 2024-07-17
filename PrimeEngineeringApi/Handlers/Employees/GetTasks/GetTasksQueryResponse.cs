using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Employees.GetTasks
{
    public class GetTasksQueryResponse
    {
        public IEnumerable<EmployeeTaskDto> Tasks { get; set; }
    }
}
