using Microsoft.AspNetCore.Components;
using XF = Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    internal class RazorComponentAdapter<TComponentBase> : IComponentAdapter<TComponentBase> where TComponentBase : ComponentBase
    {
        public object Adapt(TComponentBase component, IComponentAdapterController rootAdapter)
        {
            return new XF.ContentView();
        }
    }

    internal class RazorComponentAdapter:RazorComponentAdapter<ComponentBase>
    {
    }
}
