// ListExtensions.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

namespace Z0ne.WebKernel.Extensions;

public static class ListExtensions
{
    public static void Prepend<T>(this IList<T> list, T value)
    {
        list.Insert(index: 0, value);
    }
}
