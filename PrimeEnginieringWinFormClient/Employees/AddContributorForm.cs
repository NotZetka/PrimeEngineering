using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Common;
using System.Text;
using PrimeEnginieringWinFormClient.Models;

namespace PrimeEnginieringWinFormClient.Employees
{
    public partial class AddContributorForm : Form
    {
        private readonly int _taskId;
        private IEnumerable<Employee> _employees;
        public AddContributorForm(EmployeeTask task)
        {
            _taskId = task.Id;
            InitializeComponent();
        }

        private async void AddContributorForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.GetAsync(PrimeEnvironment.BaseUrl + "Employee/Task/" + _taskId);

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
                    MoveBack();
                }
            }
        }

        private void PopulateDataGridView()
        {
            DataGridViewEmployees.Columns.Clear();
            DataGridViewEmployees.Rows.Clear();
            DataGridViewEmployees.AutoGenerateColumns = false;

            DataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Username", DataPropertyName = "UserName" });

            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn();
            addButtonColumn.Name = "Add";
            addButtonColumn.HeaderText = "Add";
            addButtonColumn.Text = "Add";
            addButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewEmployees.Columns.Add(addButtonColumn);

            DataGridViewEmployees.DataSource = _employees.ToList();

            DataGridViewEmployees.CellContentClick += DataGridViewEmployees_CellContentClick;
        }

        private void DataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var employee = _employees.ElementAt(e.RowIndex);

            if (DataGridViewEmployees.Columns[e.ColumnIndex].Name == "Add")
            {
                AddContributor(employee.Id);
            }
        }

        private async void AddContributor(int employeeId)
        {
            var addContributorData = new
            {
                taskId = _taskId,
                newContributorId = employeeId
            };

            string json = JsonConvert.SerializeObject(addContributorData);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.PatchAsync(PrimeEnvironment.BaseUrl + "Employee/AddContributor", data);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Contributor added successfully!");
                    MoveBack();
                }
                else
                {
                    MessageBox.Show("Failed to add contributor.");
                }
            }
        }
        private class EmployeeListResponse
        {
            public IEnumerable<Employee> Employees { get; set; }
        }

        private void MoveBack()
        {
            var employeeForm = new EmployeeTaskListForm();
            employeeForm.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }
    }
}
