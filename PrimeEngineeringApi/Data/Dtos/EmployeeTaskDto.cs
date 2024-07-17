namespace PrimeEngineeringApi.Data.Dtos
{
    public class EmployeeTaskDto
    {
        public int Id { get; set; }
        public string Priority { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; } = false;
    }
}
