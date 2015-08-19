using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class PaymentRequest
        : IRequest<PaymentResponse>
    {
        public long CreditCardNumber { get; set; }
        public int VerificationCode { get; set; }

        public decimal Amount { get; set; }
    }
}