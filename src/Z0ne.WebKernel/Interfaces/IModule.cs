// IModule.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Z0ne.WebKernel.Interfaces;

public interface IModule
{
    void Load(IServiceCollection services);
}
