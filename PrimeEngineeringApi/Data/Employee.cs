namespace PrimeEngineeringApi.Data
{
    public class Employee : AppUser
    {
        public int? MenagerId { get; set; }
        public Menager? Menager { get; set; }
        public IList<Task> Tasks { get; set; } = new List<Task>();
    }
}
