using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class ProcessPaymentHandler
        : IRequestHandler<PaymentRequest, PaymentResponse>
    {
        public PaymentResponse Handle(PaymentRequest message)
        {
            var creditCardNumber = message.CreditCardNumber.ToString();
            var verificationCode = message.VerificationCode.ToString();
            if(IsValidCreditCardNumber(creditCardNumber, verificationCode) == false) return new PaymentResponse();

            ProcessPayment(message);

            return new PaymentResponse{Success = true};
        }

        private void ProcessPayment(PaymentRequest message)
        {
            //logic to charge credit card.
        }

        private bool IsValidCreditCardNumber(string creditCardNumber, string verificationCode)
        {
            if (creditCardNumber.Length == 15 && creditCardNumber.StartsWith("5")) return true;
            if (creditCardNumber.Length == 16 && creditCardNumber.StartsWith("5") == false) return true;

            return false;
        }
    }
}