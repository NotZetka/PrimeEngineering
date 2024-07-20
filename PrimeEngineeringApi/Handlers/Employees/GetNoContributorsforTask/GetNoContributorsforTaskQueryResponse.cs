using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Employees.GetNoContributorsforTask
{
    public class GetNoContributorsforTaskQueryResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
