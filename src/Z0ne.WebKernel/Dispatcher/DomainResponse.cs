// DomainResponse.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Mediator.Net.Contracts;

namespace Z0ne.WebKernel.Dispatcher;

public abstract class DomainResponse : IResponse
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
