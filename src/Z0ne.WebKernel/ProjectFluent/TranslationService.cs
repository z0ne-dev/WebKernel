// TranslationService.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using Fluent.Net;
using Z0ne.WebKernel.Interfaces;

namespace Z0ne.WebKernel.ProjectFluent;

public class TranslationService : ITranslationService
{
    private readonly ITranslationProvider provider;

    public string PreferredLanguage { get; set; }

    public TranslationService(ITranslationProvider provider, string preferredLanguage)
    {
        this.provider = provider;
        PreferredLanguage = preferredLanguage;
    }

    public string GetString(
        string id,
        string? lang = null,
        IDictionary<string, object>? args = null,
        ICollection<FluentError>? errors = null)
    {
        if (string.IsNullOrEmpty(lang))
        {
            lang = PreferredLanguage;
        }

        var ctx = provider.GetMessageContext(lang);
        var msg = ctx?.GetMessage(id);
        if (msg is not null)
        {
            return ctx!.Format(msg, args, errors);
        }

        return id;
    }
}
