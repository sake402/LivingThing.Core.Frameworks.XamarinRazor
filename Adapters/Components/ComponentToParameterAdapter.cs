namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    internal class ComponentToParameterAdapter : IComponentAdapter<ComponentToParameterBridge>
    {
        public object Adapt(ComponentToParameterBridge component, IComponentAdapterController rootAdapter)
        {
            if (component.Property != null) //return the compoenent back so the setter can know which property to assign to
                return component;
            return component.Native;
        }
    }
}
