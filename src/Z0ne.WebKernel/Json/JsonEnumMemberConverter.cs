// JsonEnumMemberConverter.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using System.Text.Json;
using System.Text.Json.Serialization;
using Z0ne.WebKernel.Extensions;

namespace Z0ne.WebKernel.Json;

public class JsonEnumMemberConverter<T> : JsonConverter<T>
    where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var name = reader.GetString();
        if (string.IsNullOrEmpty(name))
        {
            return default;
        }

        return EnumExtensions.GetEnumValue<T>(name);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetEnumMemberName());
    }
}
