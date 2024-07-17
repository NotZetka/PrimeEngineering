using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeEngineeringApi.Handlers.Accounts.Login;
using PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee;

namespace PrimeEngineeringApi.Controllers
{
    public class AccountsController : BaseApiController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Register")]
        [Authorize(Roles = "Menager")]
        public async Task<ActionResult> RegisterEmployee([FromBody] RegisterEmployeeQuery query)
        {
            await _mediator.Send(query);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result.Token);
        }
    }
}
