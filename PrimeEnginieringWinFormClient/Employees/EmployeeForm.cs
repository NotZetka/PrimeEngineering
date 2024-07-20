using PrimeEnginieringWinFormClient.Common.Static;
using PrimeEnginieringWinFormClient.Employees;

namespace PrimeEnginieringWinFormClient
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void CreateTask_Click(object sender, EventArgs e)
        {
            var createTaskForm = new CreateTaskForm();
            createTaskForm.Show();
            this.Hide();
        }

        private void GetTasksList_Click(object sender, EventArgs e)
        {
            var employeeTaskListForm = new EmployeeTaskListForm();
            employeeTaskListForm.Show();
            this.Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            UserData.Token = "";
            this.Hide();
        }
    }
}
