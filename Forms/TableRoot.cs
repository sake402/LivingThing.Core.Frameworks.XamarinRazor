
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class TableRoot : ComponentToParameterBridge<Xamarin.Forms.TableRoot, TableRoot>
    {
        public TableRoot()
        {
        }
        public TableRoot(Xamarin.Forms.TableRoot _parameter):base(_parameter)
        {
        }
		[Parameter] public Xamarin.Forms.TableSection this[System.Int32 index] { set => P[index] = value; get => P[index]; }
		[Parameter] public System.String Title { set => P.Title = value; get => P.Title; }
		[Parameter] public Xamarin.Forms.Binding BindTitle { set { P.SetBinding(Xamarin.Forms.TableRoot.TitleProperty, value); } }
		[Parameter] public Xamarin.Forms.Color TextColor { set => P.TextColor = value; get => P.TextColor; }
		[Parameter] public Xamarin.Forms.Binding BindTextColor { set { P.SetBinding(Xamarin.Forms.TableRoot.TextColorProperty, value); } }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.TableRoot.BindingContextProperty, value); } }
    }
}
