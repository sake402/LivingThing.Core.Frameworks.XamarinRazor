
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class RowDefinition : ComponentToParameterBridge<Xamarin.Forms.RowDefinition, RowDefinition>
    {
        public RowDefinition()
        {
        }
        public RowDefinition(Xamarin.Forms.RowDefinition _parameter):base(_parameter)
        {
        }
		[Parameter] public Xamarin.Forms.GridLength Height { set => P.Height = value; get => P.Height; }
		[Parameter] public Xamarin.Forms.Binding BindHeight { set { P.SetBinding(Xamarin.Forms.RowDefinition.HeightProperty, value); } }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.RowDefinition.BindingContextProperty, value); } }
    }
}
