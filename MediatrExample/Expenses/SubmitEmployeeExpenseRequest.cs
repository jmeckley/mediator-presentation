using MediatR;

namespace MediatrExample.Expenses
{
    public class SubmitEmployeeExpenseRequest 
        : IRequest<SubmitedEmployeeExpenseResponse>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}