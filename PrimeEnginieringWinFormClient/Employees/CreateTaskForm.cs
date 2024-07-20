using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common;
using PrimeEnginieringWinFormClient.Common.Static;
using System.Text;

namespace PrimeEnginieringWinFormClient.Employees
{
    public partial class CreateTaskForm : Form
    {
        public CreateTaskForm()
        {
            InitializeComponent();
            PriorityBox.Items.AddRange(new string[] { "Low", "Medium", "High" });
            DateBox.MinDate = DateTime.Today;
        }

        private async void Submit_Click(object sender, EventArgs e)
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

            await CreateTaskAsync(HeaderBox.Text, DescriptionBox.Text, priority , DateBox.Value);
        }

        private async Task CreateTaskAsync(string header, string description, int priority, DateTime deadline)
        {
            var taskData = new
            {
                header = header,
                description = description,
                priority = priority,
                dateDeadline = deadline.ToString("o") 
            };

            string json = JsonConvert.SerializeObject(taskData);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                HttpResponseMessage response = await client.PostAsync(PrimeEnvironment.BaseUrl + "Employee/Create", data);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Task created successfully!");
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
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
            this.Hide();
        }
    }
}
