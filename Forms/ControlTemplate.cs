
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ControlTemplate : ComponentToParameterBridge<Xamarin.Forms.ControlTemplate, ControlTemplate>
    {
        public ControlTemplate()
        {
        }
        public ControlTemplate(Xamarin.Forms.ControlTemplate _parameter):base(_parameter)
        {
        }

    }
}
