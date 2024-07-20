using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Employees.GetNoContributorsforTask
{
    public class GetNoContributorsforTaskQueryValidator : AbstractValidator<GetNoContributorsforTaskQuery>
    {
        public GetNoContributorsforTaskQueryValidator()
        {
            RuleFor(x=>x.TaskId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
