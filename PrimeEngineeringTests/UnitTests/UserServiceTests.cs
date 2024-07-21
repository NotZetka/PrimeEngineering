using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Services;

namespace PrimeEngineeringTests.UnitTests
{
    public class UserServiceTests
    {
        private Mock<IHttpContextAccessor> _httpContextAccessorMock = new();
        private Mock<DataContext> _dataContextMock = new Mock<DataContext>(new DbContextOptions<DataContext>());

        public UserServiceTests() { }

        [Fact]
        public void GetCurrentUserId_ShouldReturnUserId()
        {
            var userId = 1;
            SetupHttpContextMock(userId);

            var _sut = new UserService(_httpContextAccessorMock.Object, _dataContextMock.Object);

            var result = _sut.GetCurrentUserId();

            Assert.Equal(userId, result);
        }

        [Fact]
        public void GetCurrentUserId_ShouldThrowArgumentNullException()
        {
            SetupHttpContextMockWithoutClaims();

            var _sut = new UserService(_httpContextAccessorMock.Object, _dataContextMock.Object);

            var result = Assert.Throws<ArgumentNullException>(()=> _sut.GetCurrentUserId());

            Assert.NotNull(result);
        }

        private void SetupHttpContextMock(int userId)
        {
            var employee = new Employee { Id = userId, UserName = "Employee1" };
            var userClaims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) };
            var identity = new ClaimsIdentity(userClaims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(x => x.User).Returns(claimsPrincipal);
            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        }



        private void SetupHttpContextMockWithoutClaims()
        {
            var identity = new ClaimsIdentity();
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(x => x.User).Returns(claimsPrincipal);
            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);
        }
    }
}