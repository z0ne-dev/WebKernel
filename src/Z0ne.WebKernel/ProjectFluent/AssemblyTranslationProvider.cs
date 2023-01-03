// AssemblyTranslationProvider.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using System.Globalization;
using System.Reflection;
using Fluent.Net;
using Z0ne.WebKernel.Interfaces;

namespace Z0ne.WebKernel.ProjectFluent;

public class AssemblyTranslationProvider : ITranslationProvider
{
    private readonly Assembly localeAssembly;

    private readonly Dictionary<string, MessageContext> contextsByLang = new(StringComparer.Ordinal);

    public AssemblyTranslationProvider(Assembly localeAssembly)
    {
        this.localeAssembly = localeAssembly;

        ReadLocales();
    }

    public MessageContext? GetMessageContext(string lang)
    {
        return GetMessageContext(new CultureInfo(lang));
    }

    public MessageContext? GetMessageContext(CultureInfo culture)
    {
        if (culture is null)
        {
            throw new ArgumentNullException(nameof(culture));
        }

        if (!contextsByLang.TryGetValue(culture.Name, out var context))
        {
            contextsByLang.TryGetValue(culture.TwoLetterISOLanguageName, out context);
        }

        return context;
    }

    private void ReadLocales()
    {
        foreach (var name in localeAssembly.GetManifestResourceNames()
                     .Where(name => name.EndsWith(".ftl", StringComparison.Ordinal)))
        {
            var lang = name.Split(separator: '.').Reverse().Skip(count: 2).First();
            contextsByLang.TryAdd(
                lang,
                new MessageContext(
                    lang,
                    new MessageContextOptions
                        {
                            UseIsolating = false,
                        }));

            using var res = localeAssembly.GetManifestResourceStream(name);
            if (res is null)
            {
                continue;
            }

            using var stream = new StreamReader(res);
            var errors = contextsByLang[lang].AddMessages(stream);
            if (!errors.Any())
            {
                throw new AggregateException("Failed to parse translations", errors);
            }
        }
    }
}
