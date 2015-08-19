using FluentValidation;

namespace MediatrExample.OrderProcessing
{
    public class PaymentRequestValidator
        : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.CreditCardNumber).GreaterThan(0);
            RuleFor(x => x.VerificationCode).GreaterThan(0);
        }
    }
}