
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ColumnDefinition : ComponentToParameterBridge<Xamarin.Forms.ColumnDefinition, ColumnDefinition>
    {
        public ColumnDefinition()
        {
        }
        public ColumnDefinition(Xamarin.Forms.ColumnDefinition _parameter):base(_parameter)
        {
        }
		[Parameter] public Xamarin.Forms.GridLength Width { set => P.Width = value; get => P.Width; }
		[Parameter] public Xamarin.Forms.Binding BindWidth { set { P.SetBinding(Xamarin.Forms.ColumnDefinition.WidthProperty, value); } }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.ColumnDefinition.BindingContextProperty, value); } }
    }
}
