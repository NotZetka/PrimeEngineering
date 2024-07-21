using Moq;
using Microsoft.Extensions.DependencyInjection;
using PrimeEngineeringApi.Data.Repositories.EmployeesRepository;
using PrimeEngineeringApi.Services;
using PrimeEngineeringApi.Data.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json;
using PrimeEngineeringApi.Handlers.Employees.GetTasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace PrimeEngineeringTests.IntegrationTests
{
    public class EmployeeControllerTests : IClassFixture<WebApplicationFactory<PrimeEngineeringApi.Program>>
    {
        private readonly WebApplicationFactory<PrimeEngineeringApi.Program> _factory;

        public EmployeeControllerTests(WebApplicationFactory<PrimeEngineeringApi.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetTasks_ReturnsOkResponse_WithListOfTasks()
        {
            var client = CreateClient();

            var token = GenerateJwtToken("Employee");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("/Employee/Tasks");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<GetTasksQueryResponse>(stringResponse);

            Assert.NotNull(tasks);
            Assert.Equal(2, tasks.Tasks.Count());
        }

        [Fact]
        public async Task GetTasks_ReturnsUnauthorized()
        {
            var client = CreateClient();

            var token = GenerateJwtToken("Manager");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("/Employee/Tasks");

            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        }

        private HttpClient CreateClient()
        {
            var mockUserService = new Mock<IUserService>();
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();

            mockEmployeeRepository.Setup(r => r.GetTasks(It.IsAny<int>())).ReturnsAsync(new List<EmployeeTaskDto>
            {
                new EmployeeTaskDto { Id = 1, Priority = "High", Header = "Task 1", Description = "Description 1", DateCreated = DateTime.Now, DateDeadline = DateTime.Now.AddDays(1) },
                new EmployeeTaskDto { Id = 2, Priority = "Low", Header = "Task 2", Description = "Description 2", DateCreated = DateTime.Now, DateDeadline = DateTime.Now.AddDays(2) }
            });

            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(_ => mockUserService.Object);
                    services.AddScoped(_ => mockEmployeeRepository.Object);
                });
            }).CreateClient();
        }

        private string GenerateJwtToken(string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret 64 char key loooooooooooooooooooooooooooooooooooong"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
