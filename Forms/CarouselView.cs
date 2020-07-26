
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class CarouselView : ComponentToXamarinBridge<Xamarin.Forms.CarouselView, CarouselView>
    {
        public CarouselView()
        {
        }
        public CarouselView(Xamarin.Forms.CarouselView _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.CurrentItemChangedEventArgs> CurrentItemChanged { set => P.CurrentItemChanged += value; }
		EventCallback<Xamarin.Forms.CurrentItemChangedEventArgs> _onCurrentItemChanged;
		[Parameter] public EventCallback<Xamarin.Forms.CurrentItemChangedEventArgs> OnCurrentItemChanged { set { if (!_onCurrentItemChanged.HasDelegate) { P.CurrentItemChanged += (s, e) => _onCurrentItemChanged.InvokeAsync(e); } _onCurrentItemChanged = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.PositionChangedEventArgs> PositionChanged { set => P.PositionChanged += value; }
		EventCallback<Xamarin.Forms.PositionChangedEventArgs> _onPositionChanged;
		[Parameter] public EventCallback<Xamarin.Forms.PositionChangedEventArgs> OnPositionChanged { set { if (!_onPositionChanged.HasDelegate) { P.PositionChanged += (s, e) => _onPositionChanged.InvokeAsync(e); } _onPositionChanged = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ScrollToRequestEventArgs> ScrollToRequested { set => P.ScrollToRequested += value; }
		EventCallback<Xamarin.Forms.ScrollToRequestEventArgs> _onScrollToRequested;
		[Parameter] public EventCallback<Xamarin.Forms.ScrollToRequestEventArgs> OnScrollToRequested { set { if (!_onScrollToRequested.HasDelegate) { P.ScrollToRequested += (s, e) => _onScrollToRequested.InvokeAsync(e); } _onScrollToRequested = value; } }
		[Parameter] public System.EventHandler<Xamarin.Forms.ItemsViewScrolledEventArgs> Scrolled { set => P.Scrolled += value; }
		EventCallback<Xamarin.Forms.ItemsViewScrolledEventArgs> _onScrolled;
		[Parameter] public EventCallback<Xamarin.Forms.ItemsViewScrolledEventArgs> OnScrolled { set { if (!_onScrolled.HasDelegate) { P.Scrolled += (s, e) => _onScrolled.InvokeAsync(e); } _onScrolled = value; } }
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
		[Parameter] public Xamarin.Forms.Thickness PeekAreaInsets { set => P.PeekAreaInsets = value; get => P.PeekAreaInsets; }
		[Parameter] public Xamarin.Forms.Binding BindPeekAreaInsets { set { P.SetBinding(Xamarin.Forms.CarouselView.PeekAreaInsetsProperty, value); } }
		[Parameter] public System.Boolean IsBounceEnabled { set => P.IsBounceEnabled = value; get => P.IsBounceEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsBounceEnabled { set { P.SetBinding(Xamarin.Forms.CarouselView.IsBounceEnabledProperty, value); } }
		[Parameter] public System.Boolean IsSwipeEnabled { set => P.IsSwipeEnabled = value; get => P.IsSwipeEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsSwipeEnabled { set { P.SetBinding(Xamarin.Forms.CarouselView.IsSwipeEnabledProperty, value); } }
		[Parameter] public System.Boolean IsScrollAnimated { set => P.IsScrollAnimated = value; get => P.IsScrollAnimated; }
		[Parameter] public Xamarin.Forms.Binding BindIsScrollAnimated { set { P.SetBinding(Xamarin.Forms.CarouselView.IsScrollAnimatedProperty, value); } }
		[Parameter] public System.Object CurrentItem { set => P.CurrentItem = value; get => P.CurrentItem; }
		[Parameter] public Xamarin.Forms.Binding BindCurrentItem { set { P.SetBinding(Xamarin.Forms.CarouselView.CurrentItemProperty, value); } }
		[Parameter] public System.Windows.Input.ICommand CurrentItemChangedCommand { set => P.CurrentItemChangedCommand = value; get => P.CurrentItemChangedCommand; }
		[Parameter] public Xamarin.Forms.Binding BindCurrentItemChangedCommand { set { P.SetBinding(Xamarin.Forms.CarouselView.CurrentItemChangedCommandProperty, value); } }
		[Parameter] public EventCallback OnCurrentItemChangedCommand { set { CurrentItemChangedCommand = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object CurrentItemChangedCommandParameter { set => P.CurrentItemChangedCommandParameter = value; get => P.CurrentItemChangedCommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindCurrentItemChangedCommandParameter { set { P.SetBinding(Xamarin.Forms.CarouselView.CurrentItemChangedCommandParameterProperty, value); } }
		[Parameter] public System.Int32 Position { set => P.Position = value; get => P.Position; }
		[Parameter] public Xamarin.Forms.Binding BindPosition { set { P.SetBinding(Xamarin.Forms.CarouselView.PositionProperty, value); } }
		[Parameter] public System.Windows.Input.ICommand PositionChangedCommand { set => P.PositionChangedCommand = value; get => P.PositionChangedCommand; }
		[Parameter] public Xamarin.Forms.Binding BindPositionChangedCommand { set { P.SetBinding(Xamarin.Forms.CarouselView.PositionChangedCommandProperty, value); } }
		[Parameter] public EventCallback OnPositionChangedCommand { set { PositionChangedCommand = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object PositionChangedCommandParameter { set => P.PositionChangedCommandParameter = value; get => P.PositionChangedCommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindPositionChangedCommandParameter { set { P.SetBinding(Xamarin.Forms.CarouselView.PositionChangedCommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.LinearItemsLayout ItemsLayout { set => P.ItemsLayout = value; get => P.ItemsLayout; }
		[Parameter] public Xamarin.Forms.Binding BindItemsLayout { set { P.SetBinding(Xamarin.Forms.CarouselView.ItemsLayoutProperty, value); } }
		[Parameter] public System.Boolean IsScrolling { set => P.IsScrolling = value; get => P.IsScrolling; }
		[Parameter] public System.Object EmptyView { set => P.EmptyView = value; get => P.EmptyView; }
		[Parameter] public Xamarin.Forms.Binding BindEmptyView { set { P.SetBinding(Xamarin.Forms.CarouselView.EmptyViewProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate EmptyViewTemplate { set => P.EmptyViewTemplate = value; get => P.EmptyViewTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindEmptyViewTemplate { set { P.SetBinding(Xamarin.Forms.CarouselView.EmptyViewTemplateProperty, value); } }
		[Parameter] public System.Collections.IEnumerable ItemsSource { set => P.ItemsSource = value; get => P.ItemsSource; }
		[Parameter] public Xamarin.Forms.Binding BindItemsSource { set { P.SetBinding(Xamarin.Forms.CarouselView.ItemsSourceProperty, value); } }
		[Parameter] public System.Windows.Input.ICommand RemainingItemsThresholdReachedCommand { set => P.RemainingItemsThresholdReachedCommand = value; get => P.RemainingItemsThresholdReachedCommand; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThresholdReachedCommand { set { P.SetBinding(Xamarin.Forms.CarouselView.RemainingItemsThresholdReachedCommandProperty, value); } }
		[Parameter] public EventCallback OnRemainingItemsThresholdReachedCommand { set { RemainingItemsThresholdReachedCommand = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object RemainingItemsThresholdReachedCommandParameter { set => P.RemainingItemsThresholdReachedCommandParameter = value; get => P.RemainingItemsThresholdReachedCommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThresholdReachedCommandParameter { set { P.SetBinding(Xamarin.Forms.CarouselView.RemainingItemsThresholdReachedCommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.ScrollBarVisibility HorizontalScrollBarVisibility { set => P.HorizontalScrollBarVisibility = value; get => P.HorizontalScrollBarVisibility; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalScrollBarVisibility { set { P.SetBinding(Xamarin.Forms.CarouselView.HorizontalScrollBarVisibilityProperty, value); } }
		[Parameter] public Xamarin.Forms.ScrollBarVisibility VerticalScrollBarVisibility { set => P.VerticalScrollBarVisibility = value; get => P.VerticalScrollBarVisibility; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalScrollBarVisibility { set { P.SetBinding(Xamarin.Forms.CarouselView.VerticalScrollBarVisibilityProperty, value); } }
		[Parameter] public System.Int32 RemainingItemsThreshold { set => P.RemainingItemsThreshold = value; get => P.RemainingItemsThreshold; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThreshold { set { P.SetBinding(Xamarin.Forms.CarouselView.RemainingItemsThresholdProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate ItemTemplate { set => P.ItemTemplate = value; get => P.ItemTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindItemTemplate { set { P.SetBinding(Xamarin.Forms.CarouselView.ItemTemplateProperty, value); } }
		[Parameter] public Xamarin.Forms.ItemsUpdatingScrollMode ItemsUpdatingScrollMode { set => P.ItemsUpdatingScrollMode = value; get => P.ItemsUpdatingScrollMode; }
		[Parameter] public Xamarin.Forms.Binding BindItemsUpdatingScrollMode { set { P.SetBinding(Xamarin.Forms.CarouselView.ItemsUpdatingScrollModeProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions HorizontalOptions { set => P.HorizontalOptions = value; get => P.HorizontalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalOptions { set { P.SetBinding(Xamarin.Forms.CarouselView.HorizontalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Margin { set => P.Margin = value; get => P.Margin; }
		[Parameter] public Xamarin.Forms.Binding BindMargin { set { P.SetBinding(Xamarin.Forms.CarouselView.MarginProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions VerticalOptions { set => P.VerticalOptions = value; get => P.VerticalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalOptions { set { P.SetBinding(Xamarin.Forms.CarouselView.VerticalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.CarouselView.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.CarouselView.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.CarouselView.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.CarouselView.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.CarouselView.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.CarouselView.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.CarouselView.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.CarouselView.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.CarouselView.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.CarouselView.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.CarouselView.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.CarouselView.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.CarouselView.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.CarouselView.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.CarouselView.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.CarouselView.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.CarouselView.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.CarouselView.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.CarouselView.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.CarouselView.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.CarouselView.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.CarouselView.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.CarouselView.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.CarouselView.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.CarouselView.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.CarouselView.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.CarouselView.BindingContextProperty, value); } }
    }
}
