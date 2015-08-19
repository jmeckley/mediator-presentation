using MediatR;

namespace MediatrExample.Expenses
{
    public class CfoApprovalOfEmployeeExpense
        : IRequestHandler<ElevatedSubmitEmployeeExpenseRequest, SubmitedEmployeeExpenseResponse>
    {
        public SubmitedEmployeeExpenseResponse Handle(ElevatedSubmitEmployeeExpenseRequest message)
        {
            return new SubmitedEmployeeExpenseResponse
            {
                Description = message.Description,
                Amount = message.Amount,
                Approved = true,
                ApprovedBy = "the CFO"
            };
        }
    }
}