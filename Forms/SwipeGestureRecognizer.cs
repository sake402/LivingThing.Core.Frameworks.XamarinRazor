
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class SwipeGestureRecognizer : ComponentToXamarinBridge<Xamarin.Forms.SwipeGestureRecognizer, SwipeGestureRecognizer>
    {
        public SwipeGestureRecognizer()
        {
        }
        public SwipeGestureRecognizer(Xamarin.Forms.SwipeGestureRecognizer _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.SwipedEventArgs> Swiped { set => P.Swiped += value; }
		EventCallback<Xamarin.Forms.SwipedEventArgs> _onSwiped;
		[Parameter] public EventCallback<Xamarin.Forms.SwipedEventArgs> OnSwiped { set { if (!_onSwiped.HasDelegate) { P.Swiped += (s, e) => _onSwiped.InvokeAsync(e); } _onSwiped = value; } }
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
		[Parameter] public System.Windows.Input.ICommand Command { set => P.Command = value; get => P.Command; }
		[Parameter] public Xamarin.Forms.Binding BindCommand { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.CommandProperty, value); } }
		[Parameter] public EventCallback OnCommand { set { Command = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object CommandParameter { set => P.CommandParameter = value; get => P.CommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindCommandParameter { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.CommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.SwipeDirection Direction { set => P.Direction = value; get => P.Direction; }
		[Parameter] public Xamarin.Forms.Binding BindDirection { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.DirectionProperty, value); } }
		[Parameter] public System.UInt32 Threshold { set => P.Threshold = value; get => P.Threshold; }
		[Parameter] public Xamarin.Forms.Binding BindThreshold { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.ThresholdProperty, value); } }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.SwipeGestureRecognizer.BindingContextProperty, value); } }
    }
}
