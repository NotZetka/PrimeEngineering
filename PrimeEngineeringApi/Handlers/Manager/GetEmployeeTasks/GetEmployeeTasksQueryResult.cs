using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryResult
    {
        public IEnumerable<EmployeeTaskDto> Tasks { get; set; }
    }
}
