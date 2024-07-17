using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Employees.MarkFinished
{
    public class MarkFinishedQueryValidator : AbstractValidator<MarkFinishedQuery>
    {
        public MarkFinishedQueryValidator()
        {
            RuleFor(x => x.TaskId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
