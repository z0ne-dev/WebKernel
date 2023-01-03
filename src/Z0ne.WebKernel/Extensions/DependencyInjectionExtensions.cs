// DependencyInjectionExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Z0ne.WebKernel.Interfaces;

namespace Z0ne.WebKernel.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection Load(this IServiceCollection serviceCollection, IModule module)
    {
        module.Load(serviceCollection);
        return serviceCollection;
    }

    public static IServiceCollection Load<TModule>(this IServiceCollection serviceCollection)
        where TModule : IModule
    {
        return Load(serviceCollection, Activator.CreateInstance<TModule>());
    }
}
