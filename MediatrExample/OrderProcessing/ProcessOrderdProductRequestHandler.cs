using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class ProcessOrderdProductRequestHandler
        : IRequestHandler<ProcessOrderdProductRequest, ProcessOrderProductResponse>
    {
        public ProcessOrderProductResponse Handle(ProcessOrderdProductRequest message)
        {
            if (IsProductOnBackOrder(message.ProductId))
            {
                return new ProcessOrderProductResponse
                {
                    ProductId = message.ProductId,
                    Status = ProcessOrderProductResponse.Statuses.OnBackOrder
                };
            }

            UpdateInventory();

            return new ProcessOrderProductResponse
            {
                ProductId = message.ProductId,
                Status = ProcessOrderProductResponse.Statuses.InStock
            };
        }

        private void UpdateInventory()
        {
            //log goes here to update inventory
        }

        private static bool IsProductOnBackOrder(int productId)
        {
            return productId % 2 == 0;
        }
    }
}