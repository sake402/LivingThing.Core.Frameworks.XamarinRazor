
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class StructuredItemsView : ComponentToXamarinBridge<Xamarin.Forms.StructuredItemsView, StructuredItemsView>
    {
        public StructuredItemsView()
        {
        }
        public StructuredItemsView(Xamarin.Forms.StructuredItemsView _element):base(_element)
        {
        }

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
		[Parameter] public System.Object Header { set => P.Header = value; get => P.Header; }
		[Parameter] public Xamarin.Forms.Binding BindHeader { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.HeaderProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate HeaderTemplate { set => P.HeaderTemplate = value; get => P.HeaderTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindHeaderTemplate { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.HeaderTemplateProperty, value); } }
		[Parameter] public System.Object Footer { set => P.Footer = value; get => P.Footer; }
		[Parameter] public Xamarin.Forms.Binding BindFooter { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.FooterProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate FooterTemplate { set => P.FooterTemplate = value; get => P.FooterTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindFooterTemplate { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.FooterTemplateProperty, value); } }
		[Parameter] public Xamarin.Forms.IItemsLayout ItemsLayout { set => P.ItemsLayout = value; get => P.ItemsLayout; }
		[Parameter] public Xamarin.Forms.Binding BindItemsLayout { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ItemsLayoutProperty, value); } }
		[Parameter] public Xamarin.Forms.ItemSizingStrategy ItemSizingStrategy { set => P.ItemSizingStrategy = value; get => P.ItemSizingStrategy; }
		[Parameter] public Xamarin.Forms.Binding BindItemSizingStrategy { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ItemSizingStrategyProperty, value); } }
		[Parameter] public System.Object EmptyView { set => P.EmptyView = value; get => P.EmptyView; }
		[Parameter] public Xamarin.Forms.Binding BindEmptyView { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.EmptyViewProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate EmptyViewTemplate { set => P.EmptyViewTemplate = value; get => P.EmptyViewTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindEmptyViewTemplate { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.EmptyViewTemplateProperty, value); } }
		[Parameter] public System.Collections.IEnumerable ItemsSource { set => P.ItemsSource = value; get => P.ItemsSource; }
		[Parameter] public Xamarin.Forms.Binding BindItemsSource { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ItemsSourceProperty, value); } }
		[Parameter] public System.Windows.Input.ICommand RemainingItemsThresholdReachedCommand { set => P.RemainingItemsThresholdReachedCommand = value; get => P.RemainingItemsThresholdReachedCommand; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThresholdReachedCommand { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RemainingItemsThresholdReachedCommandProperty, value); } }
		[Parameter] public EventCallback OnRemainingItemsThresholdReachedCommand { set { RemainingItemsThresholdReachedCommand = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object RemainingItemsThresholdReachedCommandParameter { set => P.RemainingItemsThresholdReachedCommandParameter = value; get => P.RemainingItemsThresholdReachedCommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThresholdReachedCommandParameter { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RemainingItemsThresholdReachedCommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.ScrollBarVisibility HorizontalScrollBarVisibility { set => P.HorizontalScrollBarVisibility = value; get => P.HorizontalScrollBarVisibility; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalScrollBarVisibility { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.HorizontalScrollBarVisibilityProperty, value); } }
		[Parameter] public Xamarin.Forms.ScrollBarVisibility VerticalScrollBarVisibility { set => P.VerticalScrollBarVisibility = value; get => P.VerticalScrollBarVisibility; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalScrollBarVisibility { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.VerticalScrollBarVisibilityProperty, value); } }
		[Parameter] public System.Int32 RemainingItemsThreshold { set => P.RemainingItemsThreshold = value; get => P.RemainingItemsThreshold; }
		[Parameter] public Xamarin.Forms.Binding BindRemainingItemsThreshold { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RemainingItemsThresholdProperty, value); } }
		[Parameter] public Xamarin.Forms.DataTemplate ItemTemplate { set => P.ItemTemplate = value; get => P.ItemTemplate; }
		[Parameter] public Xamarin.Forms.Binding BindItemTemplate { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ItemTemplateProperty, value); } }
		[Parameter] public Xamarin.Forms.ItemsUpdatingScrollMode ItemsUpdatingScrollMode { set => P.ItemsUpdatingScrollMode = value; get => P.ItemsUpdatingScrollMode; }
		[Parameter] public Xamarin.Forms.Binding BindItemsUpdatingScrollMode { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ItemsUpdatingScrollModeProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions HorizontalOptions { set => P.HorizontalOptions = value; get => P.HorizontalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalOptions { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.HorizontalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Margin { set => P.Margin = value; get => P.Margin; }
		[Parameter] public Xamarin.Forms.Binding BindMargin { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.MarginProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions VerticalOptions { set => P.VerticalOptions = value; get => P.VerticalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalOptions { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.VerticalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.StructuredItemsView.BindingContextProperty, value); } }
    }
}
