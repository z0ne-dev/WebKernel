// ConfigurationBuilderExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace // ease of use for this extension method
namespace Microsoft.Extensions.Logging;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder MoveLastElementTo(
        this IConfigurationBuilder configurationBuilder,
        Predicate<IConfigurationSource> predicate)
    {
        var source = configurationBuilder.Sources[configurationBuilder.Sources.Count - 1];
        configurationBuilder.Sources.RemoveAt(configurationBuilder.Sources.Count - 1);

        for (var index = 0; index < configurationBuilder.Sources.Count; index++)
        {
            if (predicate(configurationBuilder.Sources[index]))
            {
                configurationBuilder.Sources.Insert(index + 1, source);
                break;
            }
        }

        return configurationBuilder;
    }
}
