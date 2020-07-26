
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class Application : ComponentToXamarinBridge<Xamarin.Forms.Application, Application>
    {
        public Application()
        {
        }
        public Application(Xamarin.Forms.Application _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.AppThemeChangedEventArgs> RequestedThemeChanged { set => P.RequestedThemeChanged += value; }
		EventCallback<Xamarin.Forms.AppThemeChangedEventArgs> _onRequestedThemeChanged;
		[Parameter] public EventCallback<Xamarin.Forms.AppThemeChangedEventArgs> OnRequestedThemeChanged { set { if (!_onRequestedThemeChanged.HasDelegate) { P.RequestedThemeChanged += (s, e) => _onRequestedThemeChanged.InvokeAsync(e); } _onRequestedThemeChanged = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ModalPoppedEventArgs> ModalPopped { set => P.ModalPopped += value; }
		EventCallback<Xamarin.Forms.ModalPoppedEventArgs> _onModalPopped;
		[Parameter] public EventCallback<Xamarin.Forms.ModalPoppedEventArgs> OnModalPopped { set { if (!_onModalPopped.HasDelegate) { P.ModalPopped += (s, e) => _onModalPopped.InvokeAsync(e); } _onModalPopped = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ModalPoppingEventArgs> ModalPopping { set => P.ModalPopping += value; }
		EventCallback<Xamarin.Forms.ModalPoppingEventArgs> _onModalPopping;
		[Parameter] public EventCallback<Xamarin.Forms.ModalPoppingEventArgs> OnModalPopping { set { if (!_onModalPopping.HasDelegate) { P.ModalPopping += (s, e) => _onModalPopping.InvokeAsync(e); } _onModalPopping = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ModalPushedEventArgs> ModalPushed { set => P.ModalPushed += value; }
		EventCallback<Xamarin.Forms.ModalPushedEventArgs> _onModalPushed;
		[Parameter] public EventCallback<Xamarin.Forms.ModalPushedEventArgs> OnModalPushed { set { if (!_onModalPushed.HasDelegate) { P.ModalPushed += (s, e) => _onModalPushed.InvokeAsync(e); } _onModalPushed = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ModalPushingEventArgs> ModalPushing { set => P.ModalPushing += value; }
		EventCallback<Xamarin.Forms.ModalPushingEventArgs> _onModalPushing;
		[Parameter] public EventCallback<Xamarin.Forms.ModalPushingEventArgs> OnModalPushing { set { if (!_onModalPushing.HasDelegate) { P.ModalPushing += (s, e) => _onModalPushing.InvokeAsync(e); } _onModalPushing = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Page> PageAppearing { set => P.PageAppearing += value; }
		EventCallback<Xamarin.Forms.Page> _onPageAppearing;
		[Parameter] public EventCallback<Xamarin.Forms.Page> OnPageAppearing { set { if (!_onPageAppearing.HasDelegate) { P.PageAppearing += (s, e) => _onPageAppearing.InvokeAsync(e); } _onPageAppearing = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Page> PageDisappearing { set => P.PageDisappearing += value; }
		EventCallback<Xamarin.Forms.Page> _onPageDisappearing;
		[Parameter] public EventCallback<Xamarin.Forms.Page> OnPageDisappearing { set { if (!_onPageDisappearing.HasDelegate) { P.PageDisappearing += (s, e) => _onPageDisappearing.InvokeAsync(e); } _onPageDisappearing = value; } }
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
		[Parameter] public Xamarin.Forms.Page MainPage { set => P.MainPage = value; get => P.MainPage; }
		[Parameter] public System.Int32 PanGestureId { set => P.PanGestureId = value; get => P.PanGestureId; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.Application.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.Application.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.Application.BindingContextProperty, value); } }
    }
}
