using MediatR;
using PrimeEngineeringApi.Data.Repositories.Employees;
using PrimeEngineeringApi.Services;
using PrimeEngineeringApi.Utilities.Exceptions;

namespace PrimeEngineeringApi.Handlers.Employees.MarkFinished
{
    public class MarkFinishedQueryHandler : IRequestHandler<MarkFinishedQuery, MarkFinishedQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeeRepository _employeeRepository;

        public MarkFinishedQueryHandler(IUserService userService, IEmployeeRepository employeeRepository)
        {
            _userService = userService;
            _employeeRepository = employeeRepository;
        }
        public async Task<MarkFinishedQueryResponse> Handle(MarkFinishedQuery request, CancellationToken cancellationToken)
        {
            var task = await _employeeRepository.GetTask(request.TaskId);
            var userId = _userService.GetCurrentUserId();

            if (task == null) throw new NotFoundException($"Task with id: {request.TaskId} has not been found");
            if (!task.Employees.Select(x => x.Id).Contains(userId)) throw new ForbiddenException($"User does not have access to task with id: {request.TaskId}");

            task.Finished = true;

            await _employeeRepository.SaveChangesAsync();

            return new();
        }
    }
}
