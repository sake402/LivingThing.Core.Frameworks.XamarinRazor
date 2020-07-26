using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
//using LivingThing.Core.Frameworks.Serialization;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public partial class HtmlWrapper
    {
        string Script
        {
            get
            {
                var resource = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".WebView.js");
                byte[] bytes = new byte[resource.Length];
                resource.Read(bytes, 0, bytes.Length);
                var script = Encoding.UTF8.GetString(bytes);
                return script;//.Replace("\"__\"", DOM.Serialize());
            }
        }

        [Parameter] public RenderFragment Head { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        //[Parameter] public DOMModel DOM { get; set; }

        internal void StateChanged()
        {
            InvokeAsync(StateHasChanged);
        }
    }
}
