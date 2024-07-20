namespace PrimeEnginieringWinFormClient.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }
        public string Priority { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public DateTime DateDeadline { get; set; }
        public DateTime? DateFinished { get; set; }
    }
}
