
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class MediaElement : ComponentToXamarinBridge<Xamarin.Forms.MediaElement, MediaElement>
    {
        public MediaElement()
        {
        }
        public MediaElement(Xamarin.Forms.MediaElement _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.SeekRequested> SeekRequested { set => P.SeekRequested += value; }
		EventCallback<Xamarin.Forms.SeekRequested> _onSeekRequested;
		[Parameter] public EventCallback<Xamarin.Forms.SeekRequested> OnSeekRequested { set { if (!_onSeekRequested.HasDelegate) { P.SeekRequested += (s, e) => _onSeekRequested.InvokeAsync(e); } _onSeekRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.StateRequested> StateRequested { set => P.StateRequested += value; }
		EventCallback<Xamarin.Forms.StateRequested> _onStateRequested;
		[Parameter] public EventCallback<Xamarin.Forms.StateRequested> OnStateRequested { set { if (!_onStateRequested.HasDelegate) { P.StateRequested += (s, e) => _onStateRequested.InvokeAsync(e); } _onStateRequested = value; } }
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
		[Parameter] public Xamarin.Forms.Aspect Aspect { set => P.Aspect = value; get => P.Aspect; }
		[Parameter] public Xamarin.Forms.Binding BindAspect { set { P.SetBinding(Xamarin.Forms.MediaElement.AspectProperty, value); } }
		[Parameter] public System.Boolean AutoPlay { set => P.AutoPlay = value; get => P.AutoPlay; }
		[Parameter] public Xamarin.Forms.Binding BindAutoPlay { set { P.SetBinding(Xamarin.Forms.MediaElement.AutoPlayProperty, value); } }
		[Parameter] public System.Boolean IsLooping { set => P.IsLooping = value; get => P.IsLooping; }
		[Parameter] public Xamarin.Forms.Binding BindIsLooping { set { P.SetBinding(Xamarin.Forms.MediaElement.IsLoopingProperty, value); } }
		[Parameter] public System.Boolean KeepScreenOn { set => P.KeepScreenOn = value; get => P.KeepScreenOn; }
		[Parameter] public Xamarin.Forms.Binding BindKeepScreenOn { set { P.SetBinding(Xamarin.Forms.MediaElement.KeepScreenOnProperty, value); } }
		[Parameter] public System.Boolean ShowsPlaybackControls { set => P.ShowsPlaybackControls = value; get => P.ShowsPlaybackControls; }
		[Parameter] public Xamarin.Forms.Binding BindShowsPlaybackControls { set { P.SetBinding(Xamarin.Forms.MediaElement.ShowsPlaybackControlsProperty, value); } }
		[Parameter] public System.TimeSpan Position { set => P.Position = value; get => P.Position; }
		[Parameter] public Xamarin.Forms.Binding BindPosition { set { P.SetBinding(Xamarin.Forms.MediaElement.PositionProperty, value); } }
		[Parameter] public Xamarin.Forms.MediaSource Source { set => P.Source = value; get => P.Source; }
		[Parameter] public Xamarin.Forms.Binding BindSource { set { P.SetBinding(Xamarin.Forms.MediaElement.SourceProperty, value); } }
		[Parameter] public System.Double Volume { set => P.Volume = value; get => P.Volume; }
		[Parameter] public Xamarin.Forms.Binding BindVolume { set { P.SetBinding(Xamarin.Forms.MediaElement.VolumeProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions HorizontalOptions { set => P.HorizontalOptions = value; get => P.HorizontalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalOptions { set { P.SetBinding(Xamarin.Forms.MediaElement.HorizontalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Margin { set => P.Margin = value; get => P.Margin; }
		[Parameter] public Xamarin.Forms.Binding BindMargin { set { P.SetBinding(Xamarin.Forms.MediaElement.MarginProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions VerticalOptions { set => P.VerticalOptions = value; get => P.VerticalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalOptions { set { P.SetBinding(Xamarin.Forms.MediaElement.VerticalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.MediaElement.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.MediaElement.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.MediaElement.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.MediaElement.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.MediaElement.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.MediaElement.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.MediaElement.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.MediaElement.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.MediaElement.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.MediaElement.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.MediaElement.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.MediaElement.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.MediaElement.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.MediaElement.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.MediaElement.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.MediaElement.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.MediaElement.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.MediaElement.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.MediaElement.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.MediaElement.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.MediaElement.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.MediaElement.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.MediaElement.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.MediaElement.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.MediaElement.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.MediaElement.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.MediaElement.BindingContextProperty, value); } }
    }
}
