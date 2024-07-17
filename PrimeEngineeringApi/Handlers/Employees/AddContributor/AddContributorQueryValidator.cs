using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Employees.AddContributor
{
    public class AddContributorQueryValidator : AbstractValidator<AddContributorQuery>
    {
        public AddContributorQueryValidator()
        {
            RuleFor(x=>x.NewContributorId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.TaskId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
