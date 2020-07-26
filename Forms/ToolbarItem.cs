
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class ToolbarItem : ComponentToXamarinBridge<Xamarin.Forms.ToolbarItem, ToolbarItem>
    {
        public ToolbarItem()
        {
        }
        public ToolbarItem(Xamarin.Forms.ToolbarItem _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.ElementEventArgs> ChildAdded { set => P.ChildAdded += value; }
		EventCallback<Xamarin.Forms.ElementEventArgs> _onChildAdded;
		[Parameter] public EventCallback<Xamarin.Forms.ElementEventArgs> OnChildAdded { set { if (!_onChildAdded.HasDelegate) { P.ChildAdded += (s, e) => _onChildAdded.InvokeAsync(e); } _onChildAdded = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ElementEventArgs> ChildRemoved { set => P.ChildRemoved += value; }
		EventCallback<Xamarin.Forms.ElementEventArgs> _onChildRemoved;
		[Parameter] public EventCallback<Xamarin.Forms.ElementEventArgs> OnChildRemoved { set { if (!_onChildRemoved.HasDelegate) { P.ChildRemoved += (s, e) => _onChildRemoved.InvokeAsync(e); } _onChildRemoved = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ElementEventArgs> DescendantAdded { set => P.DescendantAdded += value; }
		EventCallback<Xamarin.Forms.ElementEventArgs> _onDescendantAdded;
		[Parameter] public EventCallback<Xamarin.Forms.ElementEventArgs> OnDescendantAdded { set { if (!_onDescendantAdded.HasDelegate) { P.DescendantAdded += (s, e) => _onDescendantAdded.InvokeAsync(e); } _onDescendantAdded = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ElementEventArgs> DescendantRemoved { set => P.DescendantRemoved += value; }
		EventCallback<Xamarin.Forms.ElementEventArgs> _onDescendantRemoved;
		[Parameter] public EventCallback<Xamarin.Forms.ElementEventArgs> OnDescendantRemoved { set { if (!_onDescendantRemoved.HasDelegate) { P.DescendantRemoved += (s, e) => _onDescendantRemoved.InvokeAsync(e); } _onDescendantRemoved = value; } }
		[Parameter] public Xamarin.Forms.ToolbarItemOrder Order { set => P.Order = value; get => P.Order; }
		[Parameter] public System.Int32 Priority { set => P.Priority = value; get => P.Priority; }
		[Parameter] public System.Windows.Input.ICommand Command { set => P.Command = value; get => P.Command; }
		[Parameter] public Xamarin.Forms.Binding BindCommand { set { P.SetBinding(Xamarin.Forms.ToolbarItem.CommandProperty, value); } }
		[Parameter] public EventCallback OnCommand { set { Command = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object CommandParameter { set => P.CommandParameter = value; get => P.CommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindCommandParameter { set { P.SetBinding(Xamarin.Forms.ToolbarItem.CommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource IconImageSource { set => P.IconImageSource = value; get => P.IconImageSource; }
		[Parameter] public Xamarin.Forms.Binding BindIconImageSource { set { P.SetBinding(Xamarin.Forms.ToolbarItem.IconImageSourceProperty, value); } }
		[Parameter] public System.Boolean IsDestructive { set => P.IsDestructive = value; get => P.IsDestructive; }
		[Parameter] public Xamarin.Forms.Binding BindIsDestructive { set { P.SetBinding(Xamarin.Forms.ToolbarItem.IsDestructiveProperty, value); } }
		[Parameter] public System.String Text { set => P.Text = value; get => P.Text; }
		[Parameter] public Xamarin.Forms.Binding BindText { set { P.SetBinding(Xamarin.Forms.ToolbarItem.TextProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.ToolbarItem.IsEnabledProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.ToolbarItem.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.ToolbarItem.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.ToolbarItem.BindingContextProperty, value); } }
    }
}
