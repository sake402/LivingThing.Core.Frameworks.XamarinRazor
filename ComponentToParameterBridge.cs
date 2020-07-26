using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
//using Microsoft.MobileBlazorBindings.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public abstract class ComponentToParameterBridge: BridgeComponentBase
    {
    }

    public class ComponentToParameterBridge<TParameter, TComponent>: ComponentToParameterBridge
        where TParameter : new()
        where TComponent: ComponentBase
    {
        public ComponentToParameterBridge()
        {
        }

        public ComponentToParameterBridge(TParameter _parameter)
        {
            parameter = _parameter;
        }

        protected TParameter parameter;
        public TParameter P => parameter ??= new TParameter();
        public override object Native => P;
    }

    public class Add<T>: ComponentToParameterBridge 
    {
        [Parameter] public T Target { get; set; } 

        public override object Native => Target;
    }
}
