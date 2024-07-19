using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeEngineeringApi.Handlers.Manager.GetEmployeesList;
using PrimeEngineeringApi.Handlers.Manager.GetEmployeeStatistics;
using PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks;

namespace PrimeEngineeringApi.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseApiController
    {
        public ManagerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployeesList()
        {
            var query = new GetEmployeesListQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeTasks([FromRoute]int id)
        {
            var query = new GetEmployeeTasksQuery() { EmployeeId = id };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("stats/{id}")]
        public async Task<ActionResult> GetEmployeeStatistics([FromRoute] int id)
        {
            var query = new GetEmployeeStatisticsQuery() { EmployeeId = id };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
