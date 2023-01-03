// EntityBase.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

namespace Z0ne.WebKernel;

public abstract record EntityBase
{
    public Guid Id { get; set; }
}
