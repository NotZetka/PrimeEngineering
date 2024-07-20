using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Common;
using PrimeEnginieringWinFormClient.Models;

namespace PrimeEnginieringWinFormClient.Manager
{
    public partial class ManagerEmployeeTasksForm : Form
    {
        private IList<EmployeeTask> _tasks;
        private readonly int _id;
        public ManagerEmployeeTasksForm(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private async void ManagerEmployeeTasksForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.GetAsync(PrimeEnvironment.BaseUrl + "Manager/"+_id);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<TaskListResponse>(responseBody);
                    _tasks = responseData.Tasks.ToList();
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
            DataGridViewTasks.Columns.Clear();
            DataGridViewTasks.Rows.Clear();
            DataGridViewTasks.AutoGenerateColumns = false;

            DataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Header", DataPropertyName = "Header" });
            DataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Priority", DataPropertyName = "Priority" });
            DataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Deadline", DataPropertyName = "DateDeadline" });
            DataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Finish Date", DataPropertyName = "DateFinished" });
            DataGridViewTasks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Created Date", DataPropertyName = "DateCreated" });

            DataGridViewButtonColumn descriptionButtonColumn = new DataGridViewButtonColumn();
            descriptionButtonColumn.Name = "Description";
            descriptionButtonColumn.HeaderText = "Description";
            descriptionButtonColumn.Text = "Description";
            descriptionButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewTasks.Columns.Add(descriptionButtonColumn);

            DataGridViewTasks.DataSource = _tasks;

            DataGridViewTasks.CellContentClick += DataGridViewTasks_CellContentClick;
        }

        private void DataGridViewTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var task = _tasks[e.RowIndex];

            if (DataGridViewTasks.Columns[e.ColumnIndex].Name == "Description")
            {
                MessageBox.Show(task.Description);
            }
        }

        private class TaskListResponse
        {
            public IEnumerable<EmployeeTask> Tasks { get; set; }
        }

        private void MoveBack()
        {
            var managerForm = new ManagerForm();
            managerForm.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }
    }
}
