
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ResourceDictionary : ComponentToParameterBridge<Xamarin.Forms.ResourceDictionary, ResourceDictionary>
    {
        public ResourceDictionary()
        {
        }
        public ResourceDictionary(Xamarin.Forms.ResourceDictionary _parameter):base(_parameter)
        {
        }
		[Parameter] public System.Uri Source { set => P.Source = value; get => P.Source; }
		[Parameter] public System.Object this[System.String index] { set => P[index] = value; get => P[index]; }
    }
}
