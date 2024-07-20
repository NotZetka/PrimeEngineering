using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Manager;
using PrimeEnginieringWinFormClient.Models;

namespace PrimeEnginieringWinFormClient
{
    public partial class ManagerForm : Form
    {
        private IEnumerable<Employee> _employees;

        public ManagerForm()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            UserData.Token = "";
            this.Hide();
        }

        private async void ManagerForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.GetAsync(PrimeEnvironment.BaseUrl + "Manager");

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<EmployeeListResponse>(responseBody);
                    _employees = responseData.Employees;
                    PopulateDataGridView();
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                    MessageBox.Show(responseData.Error);
                }
            }
        }

        private void PopulateDataGridView()
        {
            DataGridViewEmployees.Columns.Clear();
            DataGridViewEmployees.Rows.Clear();
            DataGridViewEmployees.AutoGenerateColumns = false;

            DataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Username", DataPropertyName = "UserName" });

            DataGridViewButtonColumn tasksButtonColumn = new DataGridViewButtonColumn();
            tasksButtonColumn.Name = "Tasks";
            tasksButtonColumn.HeaderText = "Tasks";
            tasksButtonColumn.Text = "Tasks";
            tasksButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewEmployees.Columns.Add(tasksButtonColumn);

            DataGridViewButtonColumn statsButtonColumn = new DataGridViewButtonColumn();
            statsButtonColumn.Name = "Stats";
            statsButtonColumn.HeaderText = "Stats";
            statsButtonColumn.Text = "Stats";
            statsButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewEmployees.Columns.Add(statsButtonColumn);

            DataGridViewEmployees.DataSource = _employees.ToList();

            DataGridViewEmployees.CellContentClick += DataGridViewEmployees_CellContentClick;
        }

        private void DataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var employee = _employees.ElementAt(e.RowIndex);

            if (DataGridViewEmployees.Columns[e.ColumnIndex].Name == "Tasks")
            {
                OpenEmployeeTasksForm(employee.Id);
            }
            else if (DataGridViewEmployees.Columns[e.ColumnIndex].Name == "Stats")
            {
                OpenEmployeeStatsForm(employee.Id);
            }
        }

        private void OpenEmployeeTasksForm(int employeeId)
        {
            var employeeTasksForm = new ManagerEmployeeTasksForm(employeeId);
            employeeTasksForm.Show();
            this.Hide();
        }

        private void OpenEmployeeStatsForm(int employeeId)
        {
            var employeeStatsForm = new ManagerEmployeeStatsForm(employeeId);
            employeeStatsForm.Show();
            this.Hide();
        }
        private void Register_Click(object sender, EventArgs e)
        {
            var managerRegisterForm = new ManagerRegisterForm();
            managerRegisterForm.Show();
            this.Hide();
        }

        private class EmployeeListResponse
        {
            public IEnumerable<Employee> Employees { get; set; }
        }

    }
}
