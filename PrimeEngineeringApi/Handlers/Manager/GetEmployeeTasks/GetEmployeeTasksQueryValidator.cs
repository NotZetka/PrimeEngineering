using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryValidator : AbstractValidator<GetEmployeeTasksQuery>
    {
        public GetEmployeeTasksQueryValidator()
        {
            RuleFor(x=>x.EmployeeId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
