using Newtonsoft.Json;
using PrimeEnginieringWinFormClient.Common.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PrimeEnginieringWinFormClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var loginData = new
            {
                usernameOrEmail = LoginBox.Text,
                password = PasswordBox.Text
            };

            var json = JsonConvert.SerializeObject(loginData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(PrimeEnvironment.BaseUrl + "Accounts/Login", data);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(responseData.Token) as JwtSecurityToken;

                    var role = jsonToken?.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;
                    UserData.Token = responseData.Token;

                    if (role == "Manager")
                    {
                        var managerForm = new ManagerForm();
                        managerForm.Show();
                    }
                    else if (role == "Employee")
                    {
                        var employeeForm = new EmployeeForm();
                        employeeForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
            }
        }

        private class LoginResponse
        {
            public string Token { get; set; }
        }
    }
}