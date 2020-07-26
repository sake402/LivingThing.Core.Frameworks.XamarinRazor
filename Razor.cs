using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using XF = Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public partial class Razor<TRazorComponent> : XF.ContentPage where TRazorComponent : ComponentBase
    {
        public Razor(IServiceProvider serviceProvider, Action<TRazorComponent> parameterSetter = null)
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            renderer.AddComponent<TRazorComponent, XF.Element>(this, parameterSetter);
        }
    }

    public static class Razor
    {
        public static async Task<TElement> Create<TRazorComponent, TElement>(IServiceProvider serviceProvider, XF.Element parent = null, Action<TRazorComponent> parameterSetter = null) where TElement : class
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            var element = await renderer.AddComponent<TRazorComponent, TElement>(parent, parameterSetter);
            if (element == null)
            {
                throw new InvalidOperationException($"No root element of type {typeof(TElement)} can be found in razor component {typeof(TRazorComponent)}");
            }
            return element;
        }

        public static async Task<TElement> Create<TElement>(IServiceProvider serviceProvider, Type type, XF.Element parent = null) where TElement : class
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            var element = await renderer.AddComponent<TElement>(type, parent, null);
            if (element == null)
            {
                throw new InvalidOperationException($"No root element of type {typeof(TElement)} can be found in razor component {type}");
            }
            return element;
        }

        class RenderFragmentWrapper : ComponentBase
        {
            public RenderFragment ChildContent { get; set; }

            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.AddContent(1, ChildContent);
            }
        }
        public static async Task<TElement> Create<TElement>(IServiceProvider serviceProvider, RenderFragment childContent) where TElement : class
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            var element = await renderer.AddComponent<RenderFragmentWrapper, TElement>(null, (c)=> c.ChildContent = childContent) as TElement;
            if (element == null)
            {
                throw new InvalidOperationException($"No root element of type {typeof(TElement)} can be found in childContent");
            }
            return element;
        }
    }
}
