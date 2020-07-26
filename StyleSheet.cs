using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public class StyleSheet:ComponentBase
    {
        [Parameter] public Assembly Assembly { get; set; }
        [Parameter] public string Resource { get; set; }
        [Parameter] public string Text { get; set; }
    }
}
