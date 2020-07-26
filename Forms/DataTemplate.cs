
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class DataTemplate : ComponentToParameterBridge<Xamarin.Forms.DataTemplate, DataTemplate>
    {
        public DataTemplate()
        {
        }
        public DataTemplate(Xamarin.Forms.DataTemplate _parameter):base(_parameter)
        {
        }

    }
}
