using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Models;

namespace PrimeEnginieringWinFormClient.Employees
{
    public partial class EmployeeTaskListForm : Form
    {
        private IList<EmployeeTask> _tasks;
        public EmployeeTaskListForm()
        {
            InitializeComponent();
        }

        private async void EmployeeTaskListForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.GetAsync(PrimeEnvironment.BaseUrl + "Employee/Tasks");

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

            DataGridViewButtonColumn descriptionButtonColumn = new DataGridViewButtonColumn();
            descriptionButtonColumn.Name = "Description";
            descriptionButtonColumn.HeaderText = "Description";
            descriptionButtonColumn.Text = "Description";
            descriptionButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewTasks.Columns.Add(descriptionButtonColumn);

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewTasks.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn addContributorButtonColumn = new DataGridViewButtonColumn();
            addContributorButtonColumn.Name = "AddContributor";
            addContributorButtonColumn.HeaderText = "Add Contributor";
            addContributorButtonColumn.Text = "Add Contributor";
            addContributorButtonColumn.UseColumnTextForButtonValue = true;
            DataGridViewTasks.Columns.Add(addContributorButtonColumn);

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
            else if (DataGridViewTasks.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditTask(task);
            }
            else if (DataGridViewTasks.Columns[e.ColumnIndex].Name == "AddContributor")
            {
                AddContributor(task);
            }
        }

        private void EditTask(EmployeeTask task)
        {
            var editTaskForm = new EditTaskForm(task);
            editTaskForm.Show();
            this.Hide();
        }

        private void AddContributor(EmployeeTask task)
        {
            var addContributorForm = new AddContributorForm(task);
            addContributorForm.Show();
            this.Hide();
        }

        private class TaskListResponse
        {
            public IEnumerable<EmployeeTask> Tasks { get; set; }
        }

        private void MoveBack()
        {
            var employeeForm = new EmployeeForm();
            employeeForm.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }
    }
}
