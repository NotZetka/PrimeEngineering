using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee
{
    public class RegisterEmployeeQueryValidator : AbstractValidator<RegisterEmployeeQuery>
    {
        public RegisterEmployeeQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
