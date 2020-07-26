using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    public interface IComponentAdapter
    {

    }

    public interface IComponentAdapter<in TRazorComponent> : IComponentAdapter where TRazorComponent : IComponent
    {
        object Adapt(TRazorComponent component, IComponentAdapterController rootAdapter);
    }

    public static class ComponentAdapterExtension
    {
        public static object Adapt(this IComponentAdapter adapter, object component, IComponentAdapterController rootAdapter)
        {
            var method = adapter.GetType().GetMethod(nameof(IComponentAdapter<ComponentBase>.Adapt));
            return method.Invoke(adapter, new object[] { component, rootAdapter });
        }
    }
}
