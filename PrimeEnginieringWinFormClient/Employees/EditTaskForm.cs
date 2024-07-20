using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Common;
using System.Text;
using PrimeEnginieringWinFormClient.Models;

namespace PrimeEnginieringWinFormClient.Employees
{
    public partial class EditTaskForm : Form
    {
        private readonly int _taskId;
        public EditTaskForm(EmployeeTask task)
        {
            InitializeComponent();
            PriorityBox.Items.AddRange(new string[] { "Low", "Medium", "High" });
            PriorityBox.Text = task.Priority;
            HeaderBox.Text = task.Header;
            DescriptionBox.Text = task.Description;
            DeadLineBox.Value = task.DateDeadline;
            DeadLineBox.MinDate = task.DateDeadline.Date;
            _taskId = task.Id;
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            var priority = 1;
            switch (PriorityBox.Text)
            {
                case "High":
                    priority = 3;
                    break;
                case "Medium":
                    priority = 2;
                    break;
                case "Low":
                    priority = 1;
                    break;
            }

            await CreateTaskAsync(HeaderBox.Text, DescriptionBox.Text, priority, DeadLineBox.Value);
        }

        private async Task CreateTaskAsync(string header, string description, int priority, DateTime deadline)
        {
            var taskData = new
            {
                header = header,
                description = description,
                priority = priority,
                dateDeadline = deadline.ToString("o"),
                taskId = _taskId
            };

            string json = JsonConvert.SerializeObject(taskData);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.PatchAsync(PrimeEnvironment.BaseUrl + "Employee/edit", data);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task upated successfully!");
                    MoveBack();
                }
                else
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                    MessageBox.Show(responseData.Error);
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }
        private void MoveBack()
        {
            var tasksListForm = new EmployeeTaskListForm();
            tasksListForm.Show();
            this.Hide();
        }

        private void MarkFinishedButton_Click(object sender, EventArgs e)
        {
            Finished(_taskId);
        }
        private async void Finished(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.PatchAsync(PrimeEnvironment.BaseUrl + $"Employee/Finished/{id}", null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task marked as finished.");
                    MoveBack();
                }
                else
                {
                    MessageBox.Show("Failed to mark task as finished.");
                }
            }
        }
    }
}
