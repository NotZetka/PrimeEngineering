namespace PrimeEngineeringApi.Data
{
    public class EmployeeTask
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public IList<Employee> Employees { get; set; } = new List<Employee>();
        public Priority Priority { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; } = false;

    }
}
