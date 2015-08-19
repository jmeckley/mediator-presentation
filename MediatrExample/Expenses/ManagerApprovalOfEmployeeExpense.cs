using MediatR;

namespace MediatrExample.Expenses
{
    public class ManagerApprovalOfEmployeeExpense 
        : IRequestHandler<SubmitEmployeeExpenseRequest, SubmitedEmployeeExpenseResponse>
    {
        private readonly IMediator _mediator;

        public ManagerApprovalOfEmployeeExpense(IMediator mediator)
        {
            _mediator = mediator;
        }

        public SubmitedEmployeeExpenseResponse Handle(SubmitEmployeeExpenseRequest message)
        {
            var managerApproval = new SubmitedEmployeeExpenseResponse
            {
                Description = message.Description,
                Amount = message.Amount,
                Approved = true,
                ApprovedBy = "your manager"
            };

            if (message.Amount > 100)
            {
                var cfoApproval = _mediator.Send(new ElevatedSubmitEmployeeExpenseRequest
                {
                    Description = message.Description,
                    Amount = message.Amount
                });

                managerApproval.ApprovedBy += " and " + cfoApproval.ApprovedBy;
            }

            return managerApproval;
        }
    }
}