using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQueryValidator : AbstractValidator<GetEmployeeStatisticsQuery>
    {
        public GetEmployeeStatisticsQueryValidator()
        {
            RuleFor(x=>x.EmployeeId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
