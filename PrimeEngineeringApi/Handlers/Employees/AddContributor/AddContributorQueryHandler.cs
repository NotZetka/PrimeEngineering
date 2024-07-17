using MediatR;
using PrimeEngineeringApi.Data.Repositories.Employees;
using PrimeEngineeringApi.Services;
using PrimeEngineeringApi.Utilities.Exceptions;

namespace PrimeEngineeringApi.Handlers.Employees.AddContributor
{
    public class AddContributorQueryHandler : IRequestHandler<AddContributorQuery, AddContributorQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IEmployeeRepository _employeeRepository;

        public AddContributorQueryHandler(IUserService userService, IEmployeeRepository employeeRepository)
        {
            _userService = userService;
            _employeeRepository = employeeRepository;
        }
        public async Task<AddContributorQueryResponse> Handle(AddContributorQuery request, CancellationToken cancellationToken)
        {
            var employee = await _userService.GetCurrentEmployee();

            if(employee == null) throw new NotFoundException("Employee has not been found");

            var task = employee.Tasks.FirstOrDefault(x=>x.Id == request.TaskId);

            if(task == null) throw new NotFoundException($"Task with id {request.TaskId} has not been found");

            var newContributor = await _userService.GetEmployeeById(request.NewContributorId);

            if (newContributor == null) throw new NotFoundException("Contributor han not been found");

            if(!task.Employees.Contains(newContributor)) task.Employees.Add(newContributor);

            await _employeeRepository.SaveChangesAsync();

            return new ();
        }
    }
}
