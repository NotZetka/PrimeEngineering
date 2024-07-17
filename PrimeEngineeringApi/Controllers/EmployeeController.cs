using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeEngineeringApi.Handlers.Employees.AddContributor;
using PrimeEngineeringApi.Handlers.Employees.CreateTask;
using PrimeEngineeringApi.Handlers.Employees.EditTask;
using PrimeEngineeringApi.Handlers.Employees.GetTasks;
using PrimeEngineeringApi.Handlers.Employees.MarkFinished;

namespace PrimeEngineeringApi.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : BaseApiController
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTask([FromBody] CreateTaskQuery query)
        {
            await _mediator.Send(query);

            return Ok();
        }

        [HttpGet("Tasks")]
        public async Task<ActionResult> GetTasks()
        {
            var query = new GetTasksQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPatch("Edit")]
        public async Task<ActionResult> EditTask([FromBody] EditTaskQuery query)
        {
            await _mediator.Send(query);

            return Ok();
        }

        [HttpPatch("Finished/{id}")]
        public async Task<ActionResult> MarkTaskAsFinished([FromRoute]int id)
        {
            var query = new MarkFinishedQuery() { TaskId = id };

            await _mediator.Send(query);

            return Ok();
        }


        [HttpPatch("AddContributor")]
        public async Task<ActionResult> AddContributor([FromBody] AddContributorQuery query)
        {
            await _mediator.Send(query);

            return Ok();
        }
    }
}
