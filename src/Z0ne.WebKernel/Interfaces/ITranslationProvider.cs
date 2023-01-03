// ITranslationProvider.cs Copyright (c) z0ne.
// All Rights Reserved.
// Licensed under the EUPL 1.2 License.
// See LICENSE the project root for license information.

using System.Globalization;
using Fluent.Net;

namespace Z0ne.WebKernel.Interfaces;

public interface ITranslationProvider
{
    MessageContext? GetMessageContext(string lang);

    MessageContext? GetMessageContext(CultureInfo culture);
}
