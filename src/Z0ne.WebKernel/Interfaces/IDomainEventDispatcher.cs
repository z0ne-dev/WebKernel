// IDomainEventDispatcher.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Z0ne.WebKernel.Dispatcher;

namespace Z0ne.WebKernel.Interfaces;

public interface IDomainEventDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : DomainCommand;

    Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken)
        where TResponse : DomainResponse where TCommand : DomainCommand;

    Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        where TResponse : DomainResponse where TRequest : DomainRequest;

    IAsyncEnumerable<TResponse> CreateStream<TRequest, TResponse>(TRequest request)
        where TResponse : DomainResponse where TRequest : DomainRequest;

    Task PublishAsync(DomainEvent @event);
}
