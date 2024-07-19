using MediatR;
using PrimeEngineeringApi.Data.Repositories.EmployeesRepository;
using PrimeEngineeringApi.Services;
using PrimeEngineeringApi.Utilities.Exceptions;

namespace PrimeEngineeringApi.Handlers.Employees.EditTask
{
    public class EditTaskQueryHandler : IRequestHandler<EditTaskQuery, EditTaskQueryResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserService _userService;

        public EditTaskQueryHandler(IEmployeeRepository employeeRepository, IUserService userService)
        {
            _employeeRepository = employeeRepository;
            _userService = userService;
        }
        public async Task<EditTaskQueryResponse> Handle(EditTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _employeeRepository.GetTask(request.TaskId);
            var userId = _userService.GetCurrentUserId();

            if (task == null) throw new NotFoundException($"Task with id: {request.TaskId} has not been found");
            if(!task.Employees.Select(x=>x.Id).Contains(userId)) throw new ForbiddenException($"User does not have access to task with id: {request.TaskId}");

            if (request.Header != null) task.Header = request.Header;
            if (request.Description != null) task.Description = request.Description;
            if (request.Priority != null) task.Priority = request.Priority.Value;
            if (request.NewDedline != null && request.NewDedline > DateTime.Now) task.DateDeadline = request.NewDedline.Value;

            await _employeeRepository.SaveChangesAsync();

            return new();
        }
    }
}
