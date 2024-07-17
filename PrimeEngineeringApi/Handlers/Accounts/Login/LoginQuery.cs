using MediatR;

namespace PrimeEngineeringApi.Handlers.Accounts.Login
{
    public class LoginQuery : IRequest<LoginQueryResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
