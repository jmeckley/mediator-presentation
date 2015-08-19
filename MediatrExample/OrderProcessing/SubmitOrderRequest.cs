using System.Collections.Generic;
using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class SubmitOrderRequest
        : IRequest<SubmitOrderResponse>
    {
        public PaymentRequest Payment { get; set; }
        public IEnumerable<int> ProductIds { get; set; }

        public SubmitOrderRequest()
        {
            ProductIds = new int[0];
            Payment = new PaymentRequest();
        }
    }
}