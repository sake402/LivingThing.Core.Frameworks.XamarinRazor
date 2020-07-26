
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ColumnDefinitionCollection : ComponentToParameterBridge<Xamarin.Forms.ColumnDefinitionCollection, ColumnDefinitionCollection>
    {
        public ColumnDefinitionCollection()
        {
        }
        public ColumnDefinitionCollection(Xamarin.Forms.ColumnDefinitionCollection _parameter):base(_parameter)
        {
        }
		[Parameter] public Xamarin.Forms.ColumnDefinition this[System.Int32 index] { set => P[index] = value; get => P[index]; }
    }
}
