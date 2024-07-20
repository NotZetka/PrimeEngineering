using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Common;

namespace PrimeEnginieringWinFormClient.Manager
{
    public partial class ManagerEmployeeStatsForm : Form
    {
        private EmployeeStatistics _statictics;
        private readonly int _id;

        public ManagerEmployeeStatsForm(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void ManagerEmployeeStatsForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.GetAsync(PrimeEnvironment.BaseUrl + "Manager/stats/" + _id);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<EmployeeStatistics>(responseBody);
                    _statictics = responseData;
                    DisplayStatistics(_statictics);
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                    MessageBox.Show(responseData.Error);
                    MoveBack();
                }
            }
        }

        private void DisplayStatistics(EmployeeStatistics stats)
        {
            FinishedTasksLabel.Text = "Finished Tasks: " + stats.FinishedTasks;
            UnfinishedTasksLabel.Text = "Unfinished Tasks: " + stats.UnfinishedTasks;

            DataGridViewMonthlyStats.Columns.Clear();
            DataGridViewMonthlyStats.Rows.Clear();
            DataGridViewMonthlyStats.AutoGenerateColumns = false;

            DataGridViewMonthlyStats.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Year", DataPropertyName = "Year" });
            DataGridViewMonthlyStats.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Month", DataPropertyName = "Month" });
            DataGridViewMonthlyStats.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total Tasks", DataPropertyName = "Count" });
            DataGridViewMonthlyStats.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Finished Tasks", DataPropertyName = "Finished" });
            DataGridViewMonthlyStats.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Unfinished Tasks", DataPropertyName = "Unfinished" });

            foreach (var stat in stats.MonthlyStats)
            {
                DataGridViewMonthlyStats.Rows.Add(stat.Year, stat.Month, stat.Count, stat.Finished, stat.Unfinished);
            }
        }
        private void MoveBack()
        {
            var managerForm = new ManagerForm();
            managerForm.Show();
            this.Hide();
        }

        private class EmployeeStatistics
        {
            public int FinishedTasks { get; set; }
            public int UnfinishedTasks { get; set; }
            public IEnumerable<MonthlyStats> MonthlyStats { get; set; }
        }

        private class MonthlyStats
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Count { get; set; }
            public int Finished { get; set; }
            public int Unfinished { get; set; }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }
    }
}
