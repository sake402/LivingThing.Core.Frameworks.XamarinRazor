using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Hosting;
//using Microsoft.MobileBlazorBindings;
using System;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    internal class RazorComponent : ContentView 
    {
        public RazorComponent(Type type, IServiceProvider serviceProvider, Action<object> parameterSetter = null)
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            _ = renderer.AddComponent<Element>(type, this, parameterSetter);
        }
    }

    public class RazorComponent<TRazorComponent> : ContentView where TRazorComponent : ComponentBase
    {
        public RazorComponent(IServiceProvider serviceProvider, Action<TRazorComponent> parameterSetter = null)
        {
            var renderer = new RazorComponentRenderer(serviceProvider);
            _ = renderer.AddComponent<TRazorComponent,Element>(this, parameterSetter);
        }
    }
}
