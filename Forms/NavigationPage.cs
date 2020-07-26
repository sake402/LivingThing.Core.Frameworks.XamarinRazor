
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class NavigationPage : ComponentToXamarinBridge<Xamarin.Forms.NavigationPage, NavigationPage>
    {
        public NavigationPage()
        {
        }
        public NavigationPage(Xamarin.Forms.NavigationPage _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.NavigationEventArgs> Popped { set => P.Popped += value; }
		EventCallback<Xamarin.Forms.NavigationEventArgs> _onPopped;
		[Parameter] public EventCallback<Xamarin.Forms.NavigationEventArgs> OnPopped { set { if (!_onPopped.HasDelegate) { P.Popped += (s, e) => _onPopped.InvokeAsync(e); } _onPopped = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.NavigationEventArgs> PoppedToRoot { set => P.PoppedToRoot += value; }
		EventCallback<Xamarin.Forms.NavigationEventArgs> _onPoppedToRoot;
		[Parameter] public EventCallback<Xamarin.Forms.NavigationEventArgs> OnPoppedToRoot { set { if (!_onPoppedToRoot.HasDelegate) { P.PoppedToRoot += (s, e) => _onPoppedToRoot.InvokeAsync(e); } _onPoppedToRoot = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.NavigationEventArgs> Pushed { set => P.Pushed += value; }
		EventCallback<Xamarin.Forms.NavigationEventArgs> _onPushed;
		[Parameter] public EventCallback<Xamarin.Forms.NavigationEventArgs> OnPushed { set { if (!_onPushed.HasDelegate) { P.Pushed += (s, e) => _onPushed.InvokeAsync(e); } _onPushed = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.NavigationRequestedEventArgs> InsertPageBeforeRequested { set => P.InsertPageBeforeRequested += value; }
		EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> _onInsertPageBeforeRequested;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> OnInsertPageBeforeRequested { set { if (!_onInsertPageBeforeRequested.HasDelegate) { P.InsertPageBeforeRequested += (s, e) => _onInsertPageBeforeRequested.InvokeAsync(e); } _onInsertPageBeforeRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.NavigationRequestedEventArgs> PopRequested { set => P.PopRequested += value; }
		EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> _onPopRequested;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> OnPopRequested { set { if (!_onPopRequested.HasDelegate) { P.PopRequested += (s, e) => _onPopRequested.InvokeAsync(e); } _onPopRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.NavigationRequestedEventArgs> PopToRootRequested { set => P.PopToRootRequested += value; }
		EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> _onPopToRootRequested;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> OnPopToRootRequested { set { if (!_onPopToRootRequested.HasDelegate) { P.PopToRootRequested += (s, e) => _onPopToRootRequested.InvokeAsync(e); } _onPopToRootRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.NavigationRequestedEventArgs> PushRequested { set => P.PushRequested += value; }
		EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> _onPushRequested;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> OnPushRequested { set { if (!_onPushRequested.HasDelegate) { P.PushRequested += (s, e) => _onPushRequested.InvokeAsync(e); } _onPushRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.NavigationRequestedEventArgs> RemovePageRequested { set => P.RemovePageRequested += value; }
		EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> _onRemovePageRequested;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.NavigationRequestedEventArgs> OnRemovePageRequested { set { if (!_onRemovePageRequested.HasDelegate) { P.RemovePageRequested += (s, e) => _onRemovePageRequested.InvokeAsync(e); } _onRemovePageRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.FocusEventArgs> Focused { set => P.Focused += value; }
		EventCallback<Xamarin.Forms.FocusEventArgs> _onFocused;
		[Parameter] public EventCallback<Xamarin.Forms.FocusEventArgs> OnFocused { set { if (!_onFocused.HasDelegate) { P.Focused += (s, e) => _onFocused.InvokeAsync(e); } _onFocused = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.FocusEventArgs> Unfocused { set => P.Unfocused += value; }
		EventCallback<Xamarin.Forms.FocusEventArgs> _onUnfocused;
		[Parameter] public EventCallback<Xamarin.Forms.FocusEventArgs> OnUnfocused { set { if (!_onUnfocused.HasDelegate) { P.Unfocused += (s, e) => _onUnfocused.InvokeAsync(e); } _onUnfocused = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.Internals.EventArg<Xamarin.Forms.VisualElement>> BatchCommitted { set => P.BatchCommitted += value; }
		EventCallback<Xamarin.Forms.Internals.EventArg<Xamarin.Forms.VisualElement>> _onBatchCommitted;
		[Parameter] public EventCallback<Xamarin.Forms.Internals.EventArg<Xamarin.Forms.VisualElement>> OnBatchCommitted { set { if (!_onBatchCommitted.HasDelegate) { P.BatchCommitted += (s, e) => _onBatchCommitted.InvokeAsync(e); } _onBatchCommitted = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.VisualElement.FocusRequestArgs> FocusChangeRequested { set => P.FocusChangeRequested += value; }
		EventCallback<Xamarin.Forms.VisualElement.FocusRequestArgs> _onFocusChangeRequested;
		[Parameter] public EventCallback<Xamarin.Forms.VisualElement.FocusRequestArgs> OnFocusChangeRequested { set { if (!_onFocusChangeRequested.HasDelegate) { P.FocusChangeRequested += (s, e) => _onFocusChangeRequested.InvokeAsync(e); } _onFocusChangeRequested = value; } }
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
		[Parameter] public Xamarin.Forms.Color BarBackgroundColor { set => P.BarBackgroundColor = value; get => P.BarBackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBarBackgroundColor { set { P.SetBinding(Xamarin.Forms.NavigationPage.BarBackgroundColorProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BarTextColor { set => P.BarTextColor = value; get => P.BarTextColor; }
		[Parameter] public Xamarin.Forms.Binding BindBarTextColor { set { P.SetBinding(Xamarin.Forms.NavigationPage.BarTextColorProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource BackgroundImageSource { set => P.BackgroundImageSource = value; get => P.BackgroundImageSource; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundImageSource { set { P.SetBinding(Xamarin.Forms.NavigationPage.BackgroundImageSourceProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource IconImageSource { set => P.IconImageSource = value; get => P.IconImageSource; }
		[Parameter] public Xamarin.Forms.Binding BindIconImageSource { set { P.SetBinding(Xamarin.Forms.NavigationPage.IconImageSourceProperty, value); } }
		[Parameter] public System.Boolean IsBusy { set => P.IsBusy = value; get => P.IsBusy; }
		[Parameter] public Xamarin.Forms.Binding BindIsBusy { set { P.SetBinding(Xamarin.Forms.NavigationPage.IsBusyProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Padding { set => P.Padding = value; get => P.Padding; }
		[Parameter] public Xamarin.Forms.Binding BindPadding { set { P.SetBinding(Xamarin.Forms.NavigationPage.PaddingProperty, value); } }
		[Parameter] public System.String Title { set => P.Title = value; get => P.Title; }
		[Parameter] public Xamarin.Forms.Binding BindTitle { set { P.SetBinding(Xamarin.Forms.NavigationPage.TitleProperty, value); } }
		[Parameter] public Xamarin.Forms.Rectangle ContainerArea { set => P.ContainerArea = value; get => P.ContainerArea; }
		[Parameter] public System.Boolean IgnoresContainerArea { set => P.IgnoresContainerArea = value; get => P.IgnoresContainerArea; }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.NavigationPage.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.NavigationPage.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.NavigationPage.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.NavigationPage.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.NavigationPage.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.NavigationPage.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.NavigationPage.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.NavigationPage.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.NavigationPage.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.NavigationPage.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.NavigationPage.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.NavigationPage.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.NavigationPage.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.NavigationPage.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.NavigationPage.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.NavigationPage.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.NavigationPage.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.NavigationPage.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.NavigationPage.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.NavigationPage.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.NavigationPage.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.NavigationPage.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.NavigationPage.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.NavigationPage.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.NavigationPage.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.NavigationPage.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.NavigationPage.BindingContextProperty, value); } }
    }
}
