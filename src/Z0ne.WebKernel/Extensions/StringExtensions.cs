// StringExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

namespace Z0ne.WebKernel.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string? s)
    {
        return string.IsNullOrEmpty(s);
    }

    public static bool Matches(
        this string? left,
        string? right,
        StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
    {
        if (left.IsEmpty())
        {
            return right.IsEmpty();
        }

        if (right.IsEmpty())
        {
            return false;
        }

        return left!.Equals(right, comparison);
    }
}
