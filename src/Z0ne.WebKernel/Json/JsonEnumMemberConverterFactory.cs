// JsonEnumMemberConverterFactory.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Z0ne.WebKernel.Json;

public class JsonEnumMemberConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public sealed override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (!CanConvert(typeToConvert))
        {
            return null;
        }

        return (JsonConverter)Activator.CreateInstance(
            typeof(JsonEnumMemberConverter<>).MakeGenericType(typeToConvert),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: null,
            culture: null)!;
    }
}
