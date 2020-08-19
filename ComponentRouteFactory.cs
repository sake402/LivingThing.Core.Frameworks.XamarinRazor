using LivingThing.Core.Frameworks.XamarinRazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public class ComponentRouteFactory<TComponent> : RouteFactory where TComponent:ComponentBase
    {
        IServiceProvider ServiceProvider;
        Action<TComponent> ParameterSetter;

        public ComponentRouteFactory(IServiceProvider serviceProvider, Action<TComponent> parameterSetter = null)
        {
            ServiceProvider = serviceProvider;
            ParameterSetter = parameterSetter;
        }

        public override Element GetOrCreate()
        {
            var element = Razor.CreateAsync<TComponent, Element>(ServiceProvider, null, ParameterSetter).Result.Element;
            return element;
        }
    }
}
