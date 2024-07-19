using PrimeEngineeringApi.Data.Dtos;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeesList
{
    public class GetEmployeesListQueryResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
