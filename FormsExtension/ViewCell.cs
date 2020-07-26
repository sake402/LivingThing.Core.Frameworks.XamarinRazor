using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ViewCell
    {
        [Parameter] public new RenderFragment<object> ChildContent { get; set; }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            Property = parameters.GetValueOrDefault<string>(nameof(Property));
            ChildContent = parameters.GetValueOrDefault<RenderFragment<object>>(nameof(ChildContent));
            StateHasChanged();
            //return base.SetParametersAsync(parameters);
            return Task.CompletedTask;
        }

        //prevent rendering ViewCell ChildContent yet
        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }
    }

    public partial class ViewCellT<T>:ViewCell
    {
        [Parameter] public new RenderFragment<T> ChildContent { set => base.ChildContent = (o) => value((T)o); }
        public override Task SetParametersAsync(ParameterView parameters)
        {
            Property = parameters.GetValueOrDefault<string>(nameof(Property));
            var cc = parameters.GetValueOrDefault<RenderFragment<T>>(nameof(ChildContent));
            if (cc != null)
            {
                ChildContent = cc;
            }
            StateHasChanged();
            //return base.SetParametersAsync(parameters);
            return Task.CompletedTask;
        }
    }
}
