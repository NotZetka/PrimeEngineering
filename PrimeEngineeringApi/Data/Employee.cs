namespace PrimeEngineeringApi.Data
{
    public class Employee : AppUser
    {
        public int? ManagerId { get; set; }
        public Manager? Manager { get; set; }
        public IList<EmployeeTask> Tasks { get; set; } = new List<EmployeeTask>();
    }
}
