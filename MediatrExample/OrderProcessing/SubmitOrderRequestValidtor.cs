using System.Linq;
using FluentValidation;

namespace MediatrExample.OrderProcessing
{
    public class SubmitOrderRequestValidtor
        : AbstractValidator<SubmitOrderRequest>
    {
        public SubmitOrderRequestValidtor()
        {
            RuleFor(x => x.Payment).NotNull();
            RuleFor(x => x.ProductIds).Must(productIds => productIds.Any()).WithMessage("Please include one item in your order"); ;
        }
    }
}