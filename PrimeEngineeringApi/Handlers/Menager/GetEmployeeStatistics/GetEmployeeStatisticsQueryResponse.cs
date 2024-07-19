using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQueryResponse
    {
        public int FinishedTasks { get; set; }
        public int UnfinishedTasks { get; set; }
        public IEnumerable<MonthlyStats> MonthlyStats { get; set; }
    }
    public class MonthlyStats
    {
        public MonthlyStats(IEnumerable<EmployeeTask> tasks, int year, int month)
        {
            Count = tasks.Count();
            Finished = tasks.Where(x => x.Finished).Count();
            Unfinished = tasks.Where(x => !x.Finished).Count();
            Year = year;
            Month = month;
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
        public int Finished { get; set; }
        public int Unfinished { get; set; }
    }
}
