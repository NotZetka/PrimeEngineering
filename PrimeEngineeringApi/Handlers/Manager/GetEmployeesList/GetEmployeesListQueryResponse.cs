using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeesList
{
    public class GetEmployeesListQueryResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
