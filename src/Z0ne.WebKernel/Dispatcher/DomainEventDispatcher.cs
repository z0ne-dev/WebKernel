// DomainEventDispatcher.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Mediator.Net;
using Z0ne.WebKernel.Interfaces;

namespace Z0ne.WebKernel.Dispatcher;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : DomainCommand
    {
        return mediator.SendAsync(command, cancellationToken);
    }

    public Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken)
        where TResponse : DomainResponse where TCommand : DomainCommand
    {
        return mediator.SendAsync<TCommand, TResponse>(command, cancellationToken);
    }

    public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        where TResponse : DomainResponse where TRequest : DomainRequest
    {
        return mediator.RequestAsync<TRequest, TResponse>(request, cancellationToken);
    }

    public IAsyncEnumerable<TResponse> CreateStream<TRequest, TResponse>(TRequest request)
        where TResponse : DomainResponse where TRequest : DomainRequest
    {
        return mediator.CreateStream<TRequest, TResponse>(request);
    }

    public Task PublishAsync(DomainEvent @event)
    {
        return mediator.PublishAsync(@event);
    }
}
