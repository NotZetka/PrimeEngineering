using MediatR;

namespace PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee
{
    public class RegisterEmployeeQuery : IRequest<RegisterEmployeeQueryResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
