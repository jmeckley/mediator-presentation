using MediatR;

namespace MediatrExample.OrderProcessing
{
    public class ProcessOrderdProductRequest
        : IRequest<ProcessOrderProductResponse>
    {
        public int ProductId { get; set; }
    }
}