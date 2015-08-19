using System.Collections.Generic;

namespace MediatrExample.OrderProcessing
{
    public class SubmitOrderResponse
    {
        public bool PaymentSuccess { get; set; }
        public IEnumerable<string> ProductsShipped { get; set; }
        public IEnumerable<string> ProductsOnBackOrder { get; set; }

        public SubmitOrderResponse()
        {
            ProductsShipped = new string[0];
            ProductsOnBackOrder = new string[0];
        }
    }
}