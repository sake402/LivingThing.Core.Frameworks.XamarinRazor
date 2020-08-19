using LivingThing.Core.Frameworks.XamarinRazor.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    //this is just component to wrap the childcontent of datatemplate and render it for each item
    class DataTemplateComponent : ComponentBase
    {
        public RenderFragment<object> ChildContent { get; set; }
        public object Context { get; set; }
        public void ReRender()
        {
            InvokeAsync(StateHasChanged);
        }
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(1, ChildContent?.Invoke(Context));
            base.BuildRenderTree(builder);
        }
    }

    internal class DataTemplateNativeAdapter : INativeAdapter<XRF.DataTemplate>
    {
        public bool Add(XRF.DataTemplate template, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (template.ChildContent == null && template.Template == null)
            {
                throw new InvalidOperationException($"{typeof(XF.DataTemplate)} must have either ChildContent or Type set");
            }
            if (child != null)
            {
                //since DataTemplate is constructed in razor, the default constructor was used and this has no child element.
                //We make a new template
                //Also since datatemplate needs to be repeated for each item, the element passed here is useless
                //we create a new element in the DataTemplate Action
                XF.DataTemplate newDataTemplate = null;
                //try and guess the best root element for the data template by pre-rendering it and checking the type of the root element
                //var root = Razor.Create<object>(rootAdapter.ServiceProvider, template.ChildContent).Result;
                //if (template.ChildContent != null)
                //{
                if (child is XRF.ViewCell viewCell)
                {
                    newDataTemplate = new XF.DataTemplate(() =>
                    {
                        return new CaptureCurrentObjectForViewCell(rootAdapter.ServiceProvider, viewCell.ChildContent);
                    });
                }
                else if (child is XF.Element element)
                {
                    newDataTemplate = new XF.DataTemplate(() =>
                    {
                        return element;
                    });
                }
                //}
                //var newDataTemplate = new XF.DataTemplate(() =>
                //{
                //    return Razor.Create<DataTemplateComponent, Element>(rootAdapter.ServiceProvider, (t) =>
                //    {
                //        t.ChildContent = view.ChildContent;
                //    }).Result;
                //});
                //now we need to replace the old template with the new template
                //we find the adpater that set the old template into its parent and we ask it ro replace it
                //find the parent first
                if (newDataTemplate != null)
                {
                    rootAdapter.Parent.Replace(template, new XRF.DataTemplate(newDataTemplate) { Property = template.Property }, @throw);
                    return true;
                }
            }
            if (@throw)
                throw new InvalidOperationException($"{typeof(XF.DataTemplate)} doesn't supports ChildContent of type {child.GetType()}");
            return false;
        }

        public bool Remove(XRF.DataTemplate view, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            throw new NotImplementedException();
        }

        public bool Replace(XRF.DataTemplate view, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            throw new NotImplementedException();
        }
    }
}
