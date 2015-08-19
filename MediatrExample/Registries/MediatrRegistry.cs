using System;
using MediatR;
using MediatR.Extensions.FluentValidation;
using MediatR.Extensions.log4net;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace MediatrExample.Registries
{
    public class MediatrRegistry 
        : Registry
    {
        public MediatrRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssembliesFromApplicationBaseDirectory();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                
                scanner.Convention<HandleErrorsRegistrationConvention>();
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();

            var handlerType = For(typeof (IRequestHandler<,>));
            //handlerType.DecorateAllWith(typeof(LoggingRequestHandler<,>));
            handlerType.DecorateAllWith(typeof(ValidationRequestHandler<,>));
            handlerType.DecorateAllWith(typeof(RedirectValidationRequestHandler<,>));
        }
    }

    public class HandleErrorsRegistrationConvention : IRegistrationConvention
    {
        private static readonly Type _openHandleErrorsType = typeof(HandleErrors<>);
        private static readonly Type _openHandlerInterfaceType = typeof(IRequestHandler<,>);
        private static readonly Type _openHandleErrorsHandlerType = typeof(HandleErrorsHandler<>);

        public void Process(Type type, Registry registry)
        {
            if (type.IsAbstract) return;
            if (type.Name.EndsWith("Response") == false) return;
            
            var closedHandleErrorsType = _openHandleErrorsType.MakeGenericType(type);
            var closedHandlerInterfaceType = _openHandlerInterfaceType.MakeGenericType(closedHandleErrorsType, type);
            var closedHandleErrorsHandlerType = _openHandleErrorsHandlerType.MakeGenericType(type);

            registry.For(closedHandlerInterfaceType).Use(closedHandleErrorsHandlerType);
        }
    }
}