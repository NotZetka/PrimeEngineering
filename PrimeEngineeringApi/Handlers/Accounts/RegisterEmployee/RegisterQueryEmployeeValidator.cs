using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Accounts.RegisterEmployee
{
    public class RegisterQueryEmployeeValidator : AbstractValidator<RegisterEmployeeQuery>
    {
        public RegisterQueryEmployeeValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
