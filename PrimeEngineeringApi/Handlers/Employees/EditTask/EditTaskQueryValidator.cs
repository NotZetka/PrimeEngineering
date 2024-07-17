using FluentValidation;

namespace PrimeEngineeringApi.Handlers.Employees.EditTask
{
    public class EditTaskQueryValidator : AbstractValidator<EditTaskQuery>
    {
        public EditTaskQueryValidator()
        {
            RuleFor(x=>x.TaskId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
