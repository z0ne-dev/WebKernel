// ITranslationService.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Fluent.Net;

namespace Z0ne.WebKernel.Interfaces;

public interface ITranslationService
{
    string PreferredLanguage { get; }

    string GetString(
        string id,
        string? lang = null,
        IDictionary<string, object>? args = null,
        ICollection<FluentError>? errors = null);
}
