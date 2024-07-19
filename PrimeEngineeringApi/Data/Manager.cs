using Microsoft.AspNetCore.Identity;

namespace PrimeEngineeringApi.Data
{
    public class Manager : AppUser
    {
        public IList<Employee> Employees { get; set; }
    }
}
