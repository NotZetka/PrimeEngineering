using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryResult
    {
        public IEnumerable<EmployeeTaskDto> Tasks { get; set; }
    }
}
