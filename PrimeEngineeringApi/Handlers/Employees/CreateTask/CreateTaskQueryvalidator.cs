using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Employees.CreateTask
{
    public class CreateTaskQueryvalidator : AbstractValidator<CreateTaskQuery>
    {
        public CreateTaskQueryvalidator()
        {
            RuleFor(x => x.Header).NotEmpty().NotNull();
            RuleFor(x => x.Priority).NotEmpty().NotNull();
            RuleFor(x => x.DateDeadline).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
