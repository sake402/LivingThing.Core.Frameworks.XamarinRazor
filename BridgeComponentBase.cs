using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public abstract class BridgeComponentBase:ComponentBase
    {
        [Parameter] public string Property { get; set; }
        public abstract object Native { get; }
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
            if (false)
            {
                __builder.OpenComponent(1, typeof(CascadingValue<>).MakeGenericType(GetType()));
                __builder.AddAttribute(2, "Value", this);
                __builder.AddAttribute(3, "IsFixed", true);
                __builder.AddAttribute(4, "ChildContent", (RenderFragment)((__builder2) =>
                {
                    ChildContent?.Invoke(__builder2);
                }));
                __builder.CloseComponent();
            }
            else
            {
                ChildContent?.Invoke(__builder);
            }
            base.BuildRenderTree(__builder);
        }
    }
}
