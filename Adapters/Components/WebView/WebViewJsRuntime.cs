using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XF = Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    internal class WebViewJsRuntime : IJSRuntime
    {
        public static IJSRuntime Current { get; private set; }

        XF.WebView webView;

        public WebViewJsRuntime(XF.WebView webView)
        {
            this.webView = webView;
            Current = this;
        }

        public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            //var param = args.Serialize();
            //var script = $"window.webView.execute(\"{identifier}\", {param})";
            //var r = await webView.EvaluateJavaScriptAsync(script);
            //var v = r.DeSerialize<TValue>();
            //return v;
            return default;
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            return InvokeAsync<TValue>(identifier, args);
        }
    }
}
