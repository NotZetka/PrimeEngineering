using Microsoft.AspNetCore.Identity;

namespace PrimeEngineeringApi.Data
{
    public class Menager : AppUser
    {
        public IList<Employee> Employees { get; set; }
    }
}
