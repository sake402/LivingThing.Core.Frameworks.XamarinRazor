
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class Entry : ComponentToXamarinBridge<Xamarin.Forms.Entry, Entry>
    {
        public Entry()
        {
        }
        public Entry(Xamarin.Forms.Entry _element):base(_element)
        {
        }

		[Parameter] public System.EventHandler<Xamarin.Forms.TextChangedEventArgs> TextChanged { set => P.TextChanged += value; }
		EventCallback<Xamarin.Forms.TextChangedEventArgs> _onTextChanged;
		[Parameter] public EventCallback<Xamarin.Forms.TextChangedEventArgs> OnTextChanged { set { if (!_onTextChanged.HasDelegate) { P.TextChanged += (s, e) => _onTextChanged.InvokeAsync(e); } _onTextChanged = value; } }
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
		[Parameter] public Xamarin.Forms.TextAlignment HorizontalTextAlignment { set => P.HorizontalTextAlignment = value; get => P.HorizontalTextAlignment; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalTextAlignment { set { P.SetBinding(Xamarin.Forms.Entry.HorizontalTextAlignmentProperty, value); } }
		[Parameter] public Xamarin.Forms.TextAlignment VerticalTextAlignment { set => P.VerticalTextAlignment = value; get => P.VerticalTextAlignment; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalTextAlignment { set { P.SetBinding(Xamarin.Forms.Entry.VerticalTextAlignmentProperty, value); } }
		[Parameter] public System.Boolean IsPassword { set => P.IsPassword = value; get => P.IsPassword; }
		[Parameter] public Xamarin.Forms.Binding BindIsPassword { set { P.SetBinding(Xamarin.Forms.Entry.IsPasswordProperty, value); } }
		[Parameter] public Xamarin.Forms.FontAttributes FontAttributes { set => P.FontAttributes = value; get => P.FontAttributes; }
		[Parameter] public Xamarin.Forms.Binding BindFontAttributes { set { P.SetBinding(Xamarin.Forms.Entry.FontAttributesProperty, value); } }
		[Parameter] public System.String FontFamily { set => P.FontFamily = value; get => P.FontFamily; }
		[Parameter] public Xamarin.Forms.Binding BindFontFamily { set { P.SetBinding(Xamarin.Forms.Entry.FontFamilyProperty, value); } }
		[Parameter] public System.Double FontSize { set => P.FontSize = value; get => P.FontSize; }
		[Parameter] public Xamarin.Forms.Binding BindFontSize { set { P.SetBinding(Xamarin.Forms.Entry.FontSizeProperty, value); } }
		[Parameter] public System.Boolean IsTextPredictionEnabled { set => P.IsTextPredictionEnabled = value; get => P.IsTextPredictionEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsTextPredictionEnabled { set { P.SetBinding(Xamarin.Forms.Entry.IsTextPredictionEnabledProperty, value); } }
		[Parameter] public Xamarin.Forms.ReturnType ReturnType { set => P.ReturnType = value; get => P.ReturnType; }
		[Parameter] public Xamarin.Forms.Binding BindReturnType { set { P.SetBinding(Xamarin.Forms.Entry.ReturnTypeProperty, value); } }
		[Parameter] public System.Int32 CursorPosition { set => P.CursorPosition = value; get => P.CursorPosition; }
		[Parameter] public Xamarin.Forms.Binding BindCursorPosition { set { P.SetBinding(Xamarin.Forms.Entry.CursorPositionProperty, value); } }
		[Parameter] public System.Int32 SelectionLength { set => P.SelectionLength = value; get => P.SelectionLength; }
		[Parameter] public Xamarin.Forms.Binding BindSelectionLength { set { P.SetBinding(Xamarin.Forms.Entry.SelectionLengthProperty, value); } }
		[Parameter] public System.Windows.Input.ICommand ReturnCommand { set => P.ReturnCommand = value; get => P.ReturnCommand; }
		[Parameter] public Xamarin.Forms.Binding BindReturnCommand { set { P.SetBinding(Xamarin.Forms.Entry.ReturnCommandProperty, value); } }
		[Parameter] public EventCallback OnReturnCommand { set { ReturnCommand = new Xamarin.Forms.Command(async () => { await value.InvokeAsync(this); }); } }
		[Parameter] public System.Object ReturnCommandParameter { set => P.ReturnCommandParameter = value; get => P.ReturnCommandParameter; }
		[Parameter] public Xamarin.Forms.Binding BindReturnCommandParameter { set { P.SetBinding(Xamarin.Forms.Entry.ReturnCommandParameterProperty, value); } }
		[Parameter] public Xamarin.Forms.ClearButtonVisibility ClearButtonVisibility { set => P.ClearButtonVisibility = value; get => P.ClearButtonVisibility; }
		[Parameter] public Xamarin.Forms.Binding BindClearButtonVisibility { set { P.SetBinding(Xamarin.Forms.Entry.ClearButtonVisibilityProperty, value); } }
		[Parameter] public System.Int32 MaxLength { set => P.MaxLength = value; get => P.MaxLength; }
		[Parameter] public Xamarin.Forms.Binding BindMaxLength { set { P.SetBinding(Xamarin.Forms.Entry.MaxLengthProperty, value); } }
		[Parameter] public System.String Text { set => P.Text = value; get => P.Text; }
		[Parameter] public Xamarin.Forms.Binding BindText { set { P.SetBinding(Xamarin.Forms.Entry.TextProperty, value); } }
		[Parameter] public Xamarin.Forms.Keyboard Keyboard { set => P.Keyboard = value; get => P.Keyboard; }
		[Parameter] public Xamarin.Forms.Binding BindKeyboard { set { P.SetBinding(Xamarin.Forms.Entry.KeyboardProperty, value); } }
		[Parameter] public System.Boolean IsSpellCheckEnabled { set => P.IsSpellCheckEnabled = value; get => P.IsSpellCheckEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsSpellCheckEnabled { set { P.SetBinding(Xamarin.Forms.Entry.IsSpellCheckEnabledProperty, value); } }
		[Parameter] public System.Boolean IsReadOnly { set => P.IsReadOnly = value; get => P.IsReadOnly; }
		[Parameter] public Xamarin.Forms.Binding BindIsReadOnly { set { P.SetBinding(Xamarin.Forms.Entry.IsReadOnlyProperty, value); } }
		[Parameter] public System.String Placeholder { set => P.Placeholder = value; get => P.Placeholder; }
		[Parameter] public Xamarin.Forms.Binding BindPlaceholder { set { P.SetBinding(Xamarin.Forms.Entry.PlaceholderProperty, value); } }
		[Parameter] public Xamarin.Forms.Color PlaceholderColor { set => P.PlaceholderColor = value; get => P.PlaceholderColor; }
		[Parameter] public Xamarin.Forms.Binding BindPlaceholderColor { set { P.SetBinding(Xamarin.Forms.Entry.PlaceholderColorProperty, value); } }
		[Parameter] public Xamarin.Forms.Color TextColor { set => P.TextColor = value; get => P.TextColor; }
		[Parameter] public Xamarin.Forms.Binding BindTextColor { set { P.SetBinding(Xamarin.Forms.Entry.TextColorProperty, value); } }
		[Parameter] public System.Double CharacterSpacing { set => P.CharacterSpacing = value; get => P.CharacterSpacing; }
		[Parameter] public Xamarin.Forms.Binding BindCharacterSpacing { set { P.SetBinding(Xamarin.Forms.Entry.CharacterSpacingProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions HorizontalOptions { set => P.HorizontalOptions = value; get => P.HorizontalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindHorizontalOptions { set { P.SetBinding(Xamarin.Forms.Entry.HorizontalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.Thickness Margin { set => P.Margin = value; get => P.Margin; }
		[Parameter] public Xamarin.Forms.Binding BindMargin { set { P.SetBinding(Xamarin.Forms.Entry.MarginProperty, value); } }
		[Parameter] public Xamarin.Forms.LayoutOptions VerticalOptions { set => P.VerticalOptions = value; get => P.VerticalOptions; }
		[Parameter] public Xamarin.Forms.Binding BindVerticalOptions { set { P.SetBinding(Xamarin.Forms.Entry.VerticalOptionsProperty, value); } }
		[Parameter] public Xamarin.Forms.IVisual Visual { set => P.Visual = value; get => P.Visual; }
		[Parameter] public Xamarin.Forms.Binding BindVisual { set { P.SetBinding(Xamarin.Forms.Entry.VisualProperty, value); } }
		[Parameter] public Xamarin.Forms.FlowDirection FlowDirection { set => P.FlowDirection = value; get => P.FlowDirection; }
		[Parameter] public Xamarin.Forms.Binding BindFlowDirection { set { P.SetBinding(Xamarin.Forms.Entry.FlowDirectionProperty, value); } }
		[Parameter] public System.Double AnchorX { set => P.AnchorX = value; get => P.AnchorX; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorX { set { P.SetBinding(Xamarin.Forms.Entry.AnchorXProperty, value); } }
		[Parameter] public System.Double AnchorY { set => P.AnchorY = value; get => P.AnchorY; }
		[Parameter] public Xamarin.Forms.Binding BindAnchorY { set { P.SetBinding(Xamarin.Forms.Entry.AnchorYProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.Entry.BackgroundColorProperty, value); } }
		[Parameter] public System.Double HeightRequest { set => P.HeightRequest = value; get => P.HeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindHeightRequest { set { P.SetBinding(Xamarin.Forms.Entry.HeightRequestProperty, value); } }
		[Parameter] public System.Boolean InputTransparent { set => P.InputTransparent = value; get => P.InputTransparent; }
		[Parameter] public Xamarin.Forms.Binding BindInputTransparent { set { P.SetBinding(Xamarin.Forms.Entry.InputTransparentProperty, value); } }
		[Parameter] public System.Boolean IsEnabled { set => P.IsEnabled = value; get => P.IsEnabled; }
		[Parameter] public Xamarin.Forms.Binding BindIsEnabled { set { P.SetBinding(Xamarin.Forms.Entry.IsEnabledProperty, value); } }
		[Parameter] public System.Boolean IsVisible { set => P.IsVisible = value; get => P.IsVisible; }
		[Parameter] public Xamarin.Forms.Binding BindIsVisible { set { P.SetBinding(Xamarin.Forms.Entry.IsVisibleProperty, value); } }
		[Parameter] public System.Double MinimumHeightRequest { set => P.MinimumHeightRequest = value; get => P.MinimumHeightRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumHeightRequest { set { P.SetBinding(Xamarin.Forms.Entry.MinimumHeightRequestProperty, value); } }
		[Parameter] public System.Double MinimumWidthRequest { set => P.MinimumWidthRequest = value; get => P.MinimumWidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindMinimumWidthRequest { set { P.SetBinding(Xamarin.Forms.Entry.MinimumWidthRequestProperty, value); } }
		[Parameter] public System.Double Opacity { set => P.Opacity = value; get => P.Opacity; }
		[Parameter] public Xamarin.Forms.Binding BindOpacity { set { P.SetBinding(Xamarin.Forms.Entry.OpacityProperty, value); } }
		[Parameter] public System.Double Rotation { set => P.Rotation = value; get => P.Rotation; }
		[Parameter] public Xamarin.Forms.Binding BindRotation { set { P.SetBinding(Xamarin.Forms.Entry.RotationProperty, value); } }
		[Parameter] public System.Double RotationX { set => P.RotationX = value; get => P.RotationX; }
		[Parameter] public Xamarin.Forms.Binding BindRotationX { set { P.SetBinding(Xamarin.Forms.Entry.RotationXProperty, value); } }
		[Parameter] public System.Double RotationY { set => P.RotationY = value; get => P.RotationY; }
		[Parameter] public Xamarin.Forms.Binding BindRotationY { set { P.SetBinding(Xamarin.Forms.Entry.RotationYProperty, value); } }
		[Parameter] public System.Double Scale { set => P.Scale = value; get => P.Scale; }
		[Parameter] public Xamarin.Forms.Binding BindScale { set { P.SetBinding(Xamarin.Forms.Entry.ScaleProperty, value); } }
		[Parameter] public System.Double ScaleX { set => P.ScaleX = value; get => P.ScaleX; }
		[Parameter] public Xamarin.Forms.Binding BindScaleX { set { P.SetBinding(Xamarin.Forms.Entry.ScaleXProperty, value); } }
		[Parameter] public System.Double ScaleY { set => P.ScaleY = value; get => P.ScaleY; }
		[Parameter] public Xamarin.Forms.Binding BindScaleY { set { P.SetBinding(Xamarin.Forms.Entry.ScaleYProperty, value); } }
		[Parameter] public System.Int32 TabIndex { set => P.TabIndex = value; get => P.TabIndex; }
		[Parameter] public Xamarin.Forms.Binding BindTabIndex { set { P.SetBinding(Xamarin.Forms.Entry.TabIndexProperty, value); } }
		[Parameter] public System.Boolean IsTabStop { set => P.IsTabStop = value; get => P.IsTabStop; }
		[Parameter] public Xamarin.Forms.Binding BindIsTabStop { set { P.SetBinding(Xamarin.Forms.Entry.IsTabStopProperty, value); } }
		[Parameter] public System.Double TranslationX { set => P.TranslationX = value; get => P.TranslationX; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationX { set { P.SetBinding(Xamarin.Forms.Entry.TranslationXProperty, value); } }
		[Parameter] public System.Double TranslationY { set => P.TranslationY = value; get => P.TranslationY; }
		[Parameter] public Xamarin.Forms.Binding BindTranslationY { set { P.SetBinding(Xamarin.Forms.Entry.TranslationYProperty, value); } }
		[Parameter] public System.Double WidthRequest { set => P.WidthRequest = value; get => P.WidthRequest; }
		[Parameter] public Xamarin.Forms.Binding BindWidthRequest { set { P.SetBinding(Xamarin.Forms.Entry.WidthRequestProperty, value); } }
		[Parameter] public System.Boolean DisableLayout { set => P.DisableLayout = value; get => P.DisableLayout; }
		[Parameter] public System.Boolean IsInNativeLayout { set => P.IsInNativeLayout = value; get => P.IsInNativeLayout; }
		[Parameter] public System.Boolean IsNativeStateConsistent { set => P.IsNativeStateConsistent = value; get => P.IsNativeStateConsistent; }
		[Parameter] public System.Boolean IsPlatformEnabled { set => P.IsPlatformEnabled = value; get => P.IsPlatformEnabled; }
		[Parameter] public Xamarin.Forms.ResourceDictionary Resources { set => P.Resources = value; get => P.Resources; }
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.Entry.StyleProperty, value); } }
		[Parameter] public System.Collections.Generic.IList<System.String> StyleClass { set => P.StyleClass = value; get => P.StyleClass; }
		[Parameter] public System.Collections.Generic.IList<System.String> @class { set => P.@class = value; get => P.@class; }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.Entry.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.Entry.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.Entry.BindingContextProperty, value); } }
    }
}
