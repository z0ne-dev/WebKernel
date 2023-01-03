// EnumExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using System.Reflection;
using System.Runtime.Serialization;

// EnumExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

namespace Z0ne.WebKernel.Extensions;

public static class EnumExtensions
{
    public static string GetEnumMemberName<T>(this T value)
        where T : struct, Enum
    {
        var name = Enum.GetName(value)!;
        var memberAttribute =
            typeof(T).GetField(name)?.GetCustomAttribute(typeof(EnumMemberAttribute)) as EnumMemberAttribute;

        if (memberAttribute is not null && !string.IsNullOrEmpty(memberAttribute.Value))
        {
            return memberAttribute.Value;
        }

        return name;
    }

    public static bool TryGetEnumValue<T>(
        string value,
        out T? result,
        StringComparison stringComparison = StringComparison.Ordinal)
        where T : struct, Enum
    {
        var type = typeof(T);

        if (!type.IsEnum)
        {
            throw new InvalidOperationException();
        }

        result = default;

        if (string.IsNullOrEmpty(value))
        {
            return false;
        }

        foreach (var name in Enum.GetNames(type))
        {
            var key = name;
            var memberAttribute =
                type.GetField(name)?.GetCustomAttribute(typeof(EnumMemberAttribute)) as EnumMemberAttribute;

            if (memberAttribute is not null && !string.IsNullOrEmpty(memberAttribute.Value))
            {
                key = memberAttribute.Value;
            }

            if (key.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                result = Enum.Parse<T>(name);
                return true;
            }
        }

        return false;
    }

    // ReSharper disable once FlagArgument
    public static T GetEnumValue<T>(string value, StringComparison stringComparison = StringComparison.Ordinal)
        where T : struct, Enum
    {
        if (!TryGetEnumValue<T>(value, out var member, stringComparison))
        {
            throw new ArgumentException(nameof(value), $"unknow value: {value}");
        }

        return member!.Value;
    }

    // ReSharper disable once FlagArgument
    public static T GetEnumValueOrDefault<T>(string value, StringComparison stringComparison = StringComparison.Ordinal)
        where T : struct, Enum
    {
        if (!TryGetEnumValue<T>(value, out var member, stringComparison))
        {
            return default;
        }

        return member!.Value;
    }
}
