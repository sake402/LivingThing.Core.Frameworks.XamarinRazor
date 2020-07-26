using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Threading.Tasks;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class DataTemplate
    {
        [Parameter] public Type Template { get; set; }
        //[Parameter] public new RenderFragment<object> ChildContent { get; set; }
        /// <summary>
        /// Allows us to place a dummy template
        /// </summary>
        internal XF.DataTemplate Value { set { parameter = value; } }

        /// <summary>
        /// prevent the datatemplate from rendering its child into the render tree yet to prevent passing null to the template
        /// </summary>
        /// <param name="builder"></param>
        //protected override void BuildRenderTree(RenderTreeBuilder builder)
        //{
        //    //Add a dummy however to make sure the native adapter add function is called
        //    builder.AddContent(1, "_");
        //}

        //public override Task SetParametersAsync(ParameterView parameters)
        //{
        //    Property = parameters.GetValueOrDefault<string>(nameof(Property));
        //    ChildContent = parameters.GetValueOrDefault<RenderFragment<object>>(nameof(ChildContent));
        //    StateHasChanged();
        //    //return base.SetParametersAsync(parameters);
        //    return Task.CompletedTask;
        //}
    }

    public abstract class DataTemplateTBase : DataTemplate
    {
        public DataTemplateTBase()
        {
        }

        public abstract RenderFragment<object> TemplateChildContent { get; } 
    }

    public partial class DataTemplateT<T> : DataTemplateTBase
    {
        public DataTemplateT()
        {
            Template = typeof(T);
        }

        RenderFragment<object> childContent;
        [Parameter] public new RenderFragment<T> ChildContent { set { childContent = (o) => (b) => b.AddContent(1, value((T)o)); } }
        public override RenderFragment<object> TemplateChildContent => childContent;
        public override Task SetParametersAsync(ParameterView parameters)
        {
            Property = parameters.GetValueOrDefault<string>(nameof(Property));
            var cc = parameters.GetValueOrDefault<RenderFragment<T>>(nameof(ChildContent));
            if (cc != null)
            {
                childContent = (o) => (b) => b.AddContent(1, cc((T)o));
            }
            StateHasChanged();
            //return base.SetParametersAsync(parameters);
            return Task.CompletedTask;
        }
    }
}
 
namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    internal class ComponentToDataTemplateAdapter : IComponentAdapter<DataTemplate>
    {
        //since we defer the call o childcontent of datatemplate to prevent passing null parameter to the user provided template,
        //we have to add a dummy template to it here else there will be an exception that "LoadTemplate should not be null"
        public object Adapt(DataTemplate component, IComponentAdapterController rootAdapter)
        {
            if (component.Template == null && component.ChildContent == null)
            {
                throw new InvalidOperationException("DataTemplate must have either a Type or a ChildContent");
            }
            component.Value = new XF.DataTemplate(() =>
            {
                if (component is DataTemplateTBase tbase && tbase.TemplateChildContent != null) //if template has a child content, default to an ampty ContentView
                    return new CaptureCurrentObjectForDataTemplateAsContentView(rootAdapter.ServiceProvider, tbase.TemplateChildContent);
                else if (component.Template != null)
                    return Razor.Create<XF.Element>(rootAdapter.ServiceProvider, component.Template).Result;
                else
                    return Razor.Create<XF.Element>(rootAdapter.ServiceProvider, component.ChildContent).Result;
            });
            return component;
        }
    }
}
