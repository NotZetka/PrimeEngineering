using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeTasks
{
    public class GetEmployeeTasksQueryValidator : AbstractValidator<GetEmployeeTasksQuery>
    {
        public GetEmployeeTasksQueryValidator()
        {
            RuleFor(x=>x.EmployeeId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
