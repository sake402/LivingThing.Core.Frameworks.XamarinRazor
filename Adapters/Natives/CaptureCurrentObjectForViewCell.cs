using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using XF=Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    internal class CaptureCurrentObjectForViewCell:XF.ViewCell
    {
        public CaptureCurrentObjectForViewCell(IServiceProvider serviceProvider, RenderFragment<object> childContent)
        {
            ServiceProvider = serviceProvider;
            ChildContent = childContent;
        }

        IServiceProvider ServiceProvider;
        public RenderFragment<object> ChildContent { get; set; }
        object oldBindingContext;
        IDisposableElement<XF.ViewCell> disposableElement;
        DataTemplateComponent component;

        protected override void OnBindingContextChanged()
        {
            if (oldBindingContext != null && BindingContext == null) //happens when item is removed from collection
                return;
            //if (oldBindingContext != null && BindingContext != null && BindingContext.Equals(oldBindingContext))
            //    return;
            if (component != null)
            {
                component.Context = BindingContext;
                component.ReRender();
                return;
            }
            disposableElement?.Dispose();
            disposableElement = Razor.CreateAsync<DataTemplateComponent, XF.ViewCell>(ServiceProvider, this, (t) =>
            {
                component = t;
                t.ChildContent = ChildContent;
                t.Context = BindingContext;
            }).GetAwaiter().GetResult();
            if (View == null)
            {
                throw new InvalidOperationException($"ViewCell must have a root element of type {typeof(XF.View)}");
            }
            oldBindingContext = BindingContext;
            base.OnBindingContextChanged();
        }
    }
}
