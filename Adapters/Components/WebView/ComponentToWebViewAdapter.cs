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
        [Parameter] public string BaseUrl { get; set; }
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
            webViewRenderer = new WebViewRenderer(adapter.ServiceProvider, adapter.ServiceProvider.GetRequiredService<ILoggerFactory>(), webView);
        }

        WebViewRenderer webViewRenderer;

        public override async void Load(IWebViewDelegate renderer)
        {
            var dom = await webViewRenderer.Render();
            renderer.LoadHtml(dom, "file:///xamarinrazor");
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
