namespace MediatrExample.Expenses
{
    public class SubmitedEmployeeExpenseResponse
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }
    }
}