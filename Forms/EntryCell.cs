
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class EntryCell : ComponentToXamarinBridge<Xamarin.Forms.EntryCell, EntryCell>
    {
        public EntryCell()
        {
        }
        public EntryCell(Xamarin.Forms.EntryCell _element):base(_element)
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
		[Parameter] public Xamarin.Forms.TextAlignment HorizontalTextAlignment { set => P.HorizontalTextAlignment = value; get => P.HorizontalTextAlignment; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalTextAlignment { set { P.SetBinding(Xamarin.Forms.EntryCell.HorizontalTextAlignmentProperty, value); } }
		[Parameter] public Xamarin.Forms.TextAlignment VerticalTextAlignment { set => P.VerticalTextAlignment = value; get => P.VerticalTextAlignment; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalTextAlignment { set { P.SetBinding(Xamarin.Forms.EntryCell.VerticalTextAlignmentProperty, value); } }
		[Parameter] public Xamarin.Forms.Keyboard Keyboard { set => P.Keyboard = value; get => P.Keyboard; }
		[Parameter] public Xamarin.Forms.Binding BindKeyboard { set { P.SetBinding(Xamarin.Forms.EntryCell.KeyboardProperty, value); } }
		[Parameter] public System.String Label { set => P.Label = value; get => P.Label; }
		[Parameter] public Xamarin.Forms.Binding BindLabel { set { P.SetBinding(Xamarin.Forms.EntryCell.LabelProperty, value); } }
		[Parameter] public Xamarin.Forms.Color LabelColor { set => P.LabelColor = value; get => P.LabelColor; }
		[Parameter] public Xamarin.Forms.Binding BindLabelColor { set { P.SetBinding(Xamarin.Forms.EntryCell.LabelColorProperty, value); } }
		[Parameter] public System.String Placeholder { set => P.Placeholder = value; get => P.Placeholder; }
		[Parameter] public Xamarin.Forms.Binding BindPlaceholder { set { P.SetBinding(Xamarin.Forms.EntryCell.PlaceholderProperty, value); } }
		[Parameter] public System.String Text { set => P.Text = value; get => P.Text; }
		[Parameter] public Xamarin.Forms.Binding BindText { set { P.SetBinding(Xamarin.Forms.EntryCell.TextProperty, value); } }
		[Parameter] public System.Boolean IsContextActionsLegacyModeEnabled { set => P.IsContextActionsLegacyModeEnabled = value; get => P.IsContextActionsLegacyModeEnabled; }
		[Parameter] public System.Double Height { set => P.Height = value; get => P.Height; }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.EntryCell.IsEnabledProperty, value); } }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.EntryCell.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.EntryCell.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.EntryCell.BindingContextProperty, value); } }
    }
}
