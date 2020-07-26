using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;
using Microsoft.Extensions.Logging;
using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView;
using System.Web;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class WebView
    {
        [Parameter] public RenderFragment Head { get; set; }
        [Parameter] public RenderFragment Body { set => ChildContent = value; }
        //dont render the ChildContent yet
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }

        internal HtmlWrapper Wrapper { get; set; }
        internal void StateChanged()
        {
            Wrapper?.StateChanged();
        }
    }
}

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class ChildContentViewSource : XF.WebViewSource
    {
        public ChildContentViewSource(XRF.WebView webView, IComponentAdapterController adapter)
        {
            WebView = webView;
            RootAdapter = adapter;
        }

        IComponentAdapterController RootAdapter { get; }
        XRF.WebView WebView { get; }
        public override async void Load(IWebViewDelegate renderer)
        {
            var webViewRenderer = new WebViewRenderer(RootAdapter.ServiceProvider, RootAdapter.ServiceProvider.GetRequiredService<ILoggerFactory>(), WebView);
            var dom = await webViewRenderer.AddComponent<HtmlWrapper>((c) =>
            {
                c.Head = WebView.Head;
                c.ChildContent = WebView.ChildContent;
                WebView.Wrapper = c;
            });
            WebView.P.Navigating += (s, e) =>
            {
                if (e.Url == "http://xamarinrazor")
                {
                    //renderer.LoadHtml(dom, "xamarinrazor://webview");
                }
                else if (e.Url.Contains("__event__"))
                {
                    var uri = new Uri(e.Url);
                    var query = uri.Query;
                    var collection = HttpUtility.ParseQueryString(query);
                    var eventId = int.Parse(collection["id"]);
                    var eventParam = HttpUtility.UrlDecode(collection["v"]);
                    webViewRenderer.DOMBuilder.DispatchEvent(eventId, eventParam);
                    e.Cancel = true;
                }
            };
            renderer.LoadHtml(dom, "http://xamarinrazor");
        }
    }

    public class ComponentToWebViewAdapter : IComponentAdapter<XRF.WebView>
    {
        public object Adapt(XRF.WebView component, IComponentAdapterController rootAdapter)
        {
            var nativeView = component.P;
            if (component.ChildContent != null)
            {
                nativeView.Source = new ChildContentViewSource(component, rootAdapter);
            }
            return component;
        }
    }
}
