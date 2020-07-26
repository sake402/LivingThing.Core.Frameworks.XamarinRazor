namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    internal class ComponentToElementAdapter<TComponentToXamarinBridge> : IComponentAdapter<TComponentToXamarinBridge> where TComponentToXamarinBridge : ComponentToXamarinBridge
    {
        public object Adapt(TComponentToXamarinBridge component, IComponentAdapterController rootAdapter)
        {
            if (component.Property != null) //return the component back so the setter can know which property to assign to
                return component;
            return component.Element;
        }
    }

    internal class ComponentToElementAdapter : ComponentToElementAdapter<ComponentToXamarinBridge>
    {
    }
}
