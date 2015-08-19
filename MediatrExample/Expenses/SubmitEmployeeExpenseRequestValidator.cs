using FluentValidation;

namespace MediatrExample.Expenses
{
    public class SubmitEmployeeExpenseRequestValidator
        : AbstractValidator<SubmitEmployeeExpenseRequest>
    {
        public SubmitEmployeeExpenseRequestValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}