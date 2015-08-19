using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class RecieveOrder
        : IRequestHandler<SubmitOrderRequest, SubmitOrderResponse>
    {
        private const ProcessOrderProductResponse.Statuses BackOrdered = ProcessOrderProductResponse.Statuses.OnBackOrder ;
        private const ProcessOrderProductResponse.Statuses InStock = ProcessOrderProductResponse.Statuses.InStock;

        private readonly IMediator _mediator;
        private readonly Products _products;

        public RecieveOrder(IMediator mediator, Products products)
        {
            _mediator = mediator;
            _products = products;
        }

        public SubmitOrderResponse Handle(SubmitOrderRequest message)
        {
            var payment = _mediator.Send(message.Payment);

            if (payment.Success == false) return new SubmitOrderResponse();

            var processedProducts = message
                .ProductIds
                .Select(productId => new ProcessOrderdProductRequest {ProductId = productId})
                .Select(request => _mediator.Send(request))
                .ToArray();

            ShipOrder(processedProducts.Where(response => response.Status == InStock));

            return new SubmitOrderResponse
            {
                PaymentSuccess = true,
                ProductsShipped = processedProducts
                    .Where(response => response.Status == InStock)
                    .Select(response => _products.Get(response.ProductId))
                    .ToArray(),
                ProductsOnBackOrder = processedProducts
                    .Where(response => response.Status == BackOrdered)
                    .Select(response => _products.Get(response.ProductId))
                    .ToArray(),
            };
        }

        private void ShipOrder(IEnumerable<ProcessOrderProductResponse> products)
        {
            //ship order logic here
            //_mediator.Send(new message with products);
        }
    }
}