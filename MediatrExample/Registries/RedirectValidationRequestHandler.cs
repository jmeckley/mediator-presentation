using System;
using System.Linq;
using FluentValidation;
using MediatR;

namespace MediatrExample.Registries
{
    public class RedirectValidationRequestHandler<TRequest, TResponse> 
        : IRequestHandler<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _innerHandler;
        private readonly IMediator _mediator;

        public RedirectValidationRequestHandler(IRequestHandler<TRequest, TResponse> innerHandler, IMediator mediator)
        {
            _innerHandler = innerHandler;
            _mediator = mediator;
        }

        public TResponse Handle(TRequest message)
        {
            try
            {
                return _innerHandler.Handle(message);
            }
            catch (ValidationException exception)
            {
                return _mediator.Send(new HandleErrors<TResponse> {Errors = exception});
            }
        }
    }

    public class HandleErrors<TResponse> : IRequest<TResponse>
    {
        public ValidationException Errors { get; set; }
    }

    public class HandleErrorsHandler<TResponse> : IRequestHandler<HandleErrors<TResponse>, TResponse>
    {
        private readonly TResponse _response;

        public HandleErrorsHandler(TResponse response)
        {
            _response = response;
        }

        public TResponse Handle(HandleErrors<TResponse> message)
        {
            message.Errors.Errors.ToList().ForEach(Console.WriteLine);
            return _response;
        }
    }
}