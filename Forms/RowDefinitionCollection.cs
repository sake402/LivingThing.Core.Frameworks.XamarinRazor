
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class RowDefinitionCollection : ComponentToParameterBridge<Xamarin.Forms.RowDefinitionCollection, RowDefinitionCollection>
    {
        public RowDefinitionCollection()
        {
        }
        public RowDefinitionCollection(Xamarin.Forms.RowDefinitionCollection _parameter):base(_parameter)
        {
        }
		[Parameter] public Xamarin.Forms.RowDefinition this[System.Int32 index] { set => P[index] = value; get => P[index]; }
    }
}
