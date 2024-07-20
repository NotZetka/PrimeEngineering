using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common;
using PrimeEnginieringWinFormClient.Common.Static;
using System.Text;

namespace PrimeEnginieringWinFormClient.Manager
{
    public partial class ManagerRegisterForm : Form
    {
        public ManagerRegisterForm()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MoveBack();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if(PasswordBox.Text != ConfirmPasswordBox.Text) MessageBox.Show("Passwords don't match");
            else
            {
                var loginData = new
                {
                    userName = UsernameBox.Text,
                    email = EmailBox.Text,
                    password = PasswordBox.Text,
                };

                var json = JsonConvert.SerializeObject(loginData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserData.Token);
                    HttpResponseMessage response = await client.PostAsync(PrimeEnvironment.BaseUrl + "Accounts/Register", data);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User registered successfully");
                        MoveBack();
                        this.Hide();
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                        MessageBox.Show(responseData.Error);
                    }
                }
            }
        }
        private void MoveBack()
        {
            var managerForm = new ManagerForm();
            managerForm.Show();
            this.Hide();
        }
    }
}
