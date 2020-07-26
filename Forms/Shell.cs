
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class Shell : ComponentToXamarinBridge<Xamarin.Forms.Shell, Shell>
    {
        public Shell()
        {
        }
        public Shell(Xamarin.Forms.Shell _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.ShellNavigatedEventArgs> Navigated { set => P.Navigated += value; }
		EventCallback<Xamarin.Forms.ShellNavigatedEventArgs> _onNavigated;
		[Parameter] public EventCallback<Xamarin.Forms.ShellNavigatedEventArgs> OnNavigated { set { if (!_onNavigated.HasDelegate) { P.Navigated += (s, e) => _onNavigated.InvokeAsync(e); } _onNavigated = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ShellNavigatingEventArgs> Navigating { set => P.Navigating += value; }
		EventCallback<Xamarin.Forms.ShellNavigatingEventArgs> _onNavigating;
		[Parameter] public EventCallback<Xamarin.Forms.ShellNavigatingEventArgs> OnNavigating { set { if (!_onNavigating.HasDelegate) { P.Navigating += (s, e) => _onNavigating.InvokeAsync(e); } _onNavigating = value; } }
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
		[Parameter] public Xamarin.Forms.ScrollMode FlyoutVerticalScrollMode { set => P.FlyoutVerticalScrollMode = value; get => P.FlyoutVerticalScrollMode; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutVerticalScrollMode { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutVerticalScrollModeProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource FlyoutIcon { set => P.FlyoutIcon = value; get => P.FlyoutIcon; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutIcon { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutIconProperty, value); } }
		[Parameter] public Xamarin.Forms.ShellItem CurrentItem { set => P.CurrentItem = value; get => P.CurrentItem; }
		[Parameter] public Xamarin.Forms.Binding BindCurrentItem { set { P.SetBinding(Xamarin.Forms.Shell.CurrentItemProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource FlyoutBackgroundImage { set => P.FlyoutBackgroundImage = value; get => P.FlyoutBackgroundImage; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutBackgroundImage { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutBackgroundImageProperty, value); } }
		[Parameter] public Xamarin.Forms.Aspect FlyoutBackgroundImageAspect { set => P.FlyoutBackgroundImageAspect = value; get => P.FlyoutBackgroundImageAspect; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutBackgroundImageAspect { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutBackgroundImageAspectProperty, value); } }
		[Parameter] public Xamarin.Forms.Color FlyoutBackgroundColor { set => P.FlyoutBackgroundColor = value; get => P.FlyoutBackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutBackgroundColor { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutBackgroundColorProperty, value); } }
		[Parameter] public Xamarin.Forms.FlyoutBehavior FlyoutBehavior { set => P.FlyoutBehavior = value; get => P.FlyoutBehavior; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutBehavior { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutBehaviorProperty, value); } }
		[Parameter] public System.Object FlyoutHeader { set => P.FlyoutHeader = value; get => P.FlyoutHeader; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutHeader { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutHeaderProperty, value); } }
		[Parameter] public Xamarin.Forms.FlyoutHeaderBehavior FlyoutHeaderBehavior { set => P.FlyoutHeaderBehavior = value; get => P.FlyoutHeaderBehavior; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutHeaderBehavior { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutHeaderBehaviorProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate FlyoutHeaderTemplate { set => P.FlyoutHeaderTemplate = value; get => P.FlyoutHeaderTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutHeaderTemplate { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutHeaderTemplateProperty, value); } }
		[Parameter] public System.Boolean FlyoutIsPresented { set => P.FlyoutIsPresented = value; get => P.FlyoutIsPresented; }
		[Parameter] public Xamarin.Forms.Binding BindFlyoutIsPresented { set { P.SetBinding(Xamarin.Forms.Shell.FlyoutIsPresentedProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate ItemTemplate { set => P.ItemTemplate = value; get => P.ItemTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindItemTemplate { set { P.SetBinding(Xamarin.Forms.Shell.ItemTemplateProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate MenuItemTemplate { set => P.MenuItemTemplate = value; get => P.MenuItemTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindMenuItemTemplate { set { P.SetBinding(Xamarin.Forms.Shell.MenuItemTemplateProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource BackgroundImageSource { set => P.BackgroundImageSource = value; get => P.BackgroundImageSource; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundImageSource { set { P.SetBinding(Xamarin.Forms.Shell.BackgroundImageSourceProperty, value); } }
		[Parameter] public Xamarin.Forms.ImageSource IconImageSource { set => P.IconImageSource = value; get => P.IconImageSource; }
		[Parameter] public Xamarin.Forms.Binding BindIconImageSource { set { P.SetBinding(Xamarin.Forms.Shell.IconImageSourceProperty, value); } }
		[Parameter] public System.Boolean IsBusy { set => P.IsBusy = value; get => P.IsBusy; }
		[Parameter] public Xamarin.Forms.Binding BindIsBusy { set { P.SetBinding(Xamarin.Forms.Shell.IsBusyProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Padding { set => P.Padding = value; get => P.Padding; }
		[Parameter] public Xamarin.Forms.Binding BindPadding { set { P.SetBinding(Xamarin.Forms.Shell.PaddingProperty, value); } }
		[Parameter] public System.String Title { set => P.Title = value; get => P.Title; }
		[Parameter] public Xamarin.Forms.Binding BindTitle { set { P.SetBinding(Xamarin.Forms.Shell.TitleProperty, value); } }
		[Parameter] public Xamarin.Forms.Rectangle ContainerArea { set => P.ContainerArea = value; get => P.ContainerArea; }
		[Parameter] public System.Boolean IgnoresContainerArea { set => P.IgnoresContainerArea = value; get => P.IgnoresContainerArea; }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.Shell.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.Shell.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.Shell.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.Shell.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.Shell.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.Shell.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.Shell.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.Shell.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.Shell.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.Shell.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.Shell.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.Shell.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.Shell.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.Shell.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.Shell.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.Shell.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.Shell.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.Shell.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.Shell.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.Shell.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.Shell.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.Shell.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.Shell.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.Shell.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.Shell.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.Shell.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.Shell.BindingContextProperty, value); } }
    }
}
