using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PrimeEngineeringApi.Data;
using PrimeEngineeringApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PrimeEngineeringTests.UnitTests
{
    public class TokenServiceTests
    {
        private readonly Mock<UserManager<AppUser>> _userManagerMock;
        private readonly TokenService _tokenService;
        private readonly Mock<IConfiguration> _configurationMock;

        public TokenServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock.Setup(c => c["TokenKey"])
                .Returns("super secret 64 char key loooooooooooooooooooooooooooooooooooong");

            var userStoreMock = new Mock<IUserStore<AppUser>>();
            _userManagerMock = new Mock<UserManager<AppUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _tokenService = new TokenService(_configurationMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task CreateToken_ShouldReturnToken()
        {
            var user = new AppUser { Id = 1, UserName = "Manager1" };
            _userManagerMock.Setup(um => um.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Manager" });

            var token = await _tokenService.CreateToken(user);

            Assert.NotNull(token);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configurationMock.Object["TokenKey"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userIdClaim = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;
            var usernameClaim = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName).Value;
            Assert.Equal(user.Id.ToString(), userIdClaim);
            Assert.Equal(user.UserName, usernameClaim);
            var roleClaim = jwtToken.Claims.Where(claim => claim.Type == "role").FirstOrDefault();
            Assert.NotNull(roleClaim);
            Assert.Equal("Manager", roleClaim.Value);
        }
    }
}