using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    internal class CaptureCurrentObjectForDataTemplateAsContentView:ContentView
    {
        public CaptureCurrentObjectForDataTemplateAsContentView(IServiceProvider serviceProvider, RenderFragment<object> childContent)
        {
            ServiceProvider = serviceProvider;
            ChildContent = childContent;
        }

        IServiceProvider ServiceProvider;
        public RenderFragment<object> ChildContent { get; set; }

        protected override void OnBindingContextChanged()
        {
            Razor.Create<DataTemplateComponent, View>(ServiceProvider, this, (t) =>
            {
                t.ChildContent = ChildContent;
                t.Context = BindingContext;
            }).GetAwaiter().GetResult();
            base.OnBindingContextChanged();
        }
    }
}
