using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public interface IWebViewPathResolver
    {
        string ResolvePath(string url);
    }
}
