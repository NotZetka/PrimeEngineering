using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Manager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQueryValidator : AbstractValidator<GetEmployeeStatisticsQuery>
    {
        public GetEmployeeStatisticsQueryValidator()
        {
            RuleFor(x=>x.EmployeeId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
