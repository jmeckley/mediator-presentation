namespace MediatrExample.OrderProcessing
{
    public class ProcessOrderProductResponse
    {
        public Statuses Status { get; set; }
        public int ProductId { get; set; } 

        public enum Statuses
        {
            OnBackOrder,
            InStock
        }
    }
}