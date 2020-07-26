
using Microsoft.AspNetCore.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class Span : ComponentToXamarinBridge<Xamarin.Forms.Span, Span>
    {
        public Span()
        {
        }
        public Span(Xamarin.Forms.Span _element):base(_element)
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
		[Parameter] public Xamarin.Forms.Style Style { set => P.Style = value; get => P.Style; }
		[Parameter] public Xamarin.Forms.Binding BindStyle { set { P.SetBinding(Xamarin.Forms.Span.StyleProperty, value); } }
		[Parameter] public Xamarin.Forms.Color BackgroundColor { set => P.BackgroundColor = value; get => P.BackgroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindBackgroundColor { set { P.SetBinding(Xamarin.Forms.Span.BackgroundColorProperty, value); } }
		[Parameter] public Xamarin.Forms.Color TextColor { set => P.TextColor = value; get => P.TextColor; }
		[Parameter] public Xamarin.Forms.Binding BindTextColor { set { P.SetBinding(Xamarin.Forms.Span.TextColorProperty, value); } }
		[Parameter] public System.Double CharacterSpacing { set => P.CharacterSpacing = value; get => P.CharacterSpacing; }
		[Parameter] public Xamarin.Forms.Binding BindCharacterSpacing { set { P.SetBinding(Xamarin.Forms.Span.CharacterSpacingProperty, value); } }
		[Parameter] public Xamarin.Forms.Color ForegroundColor { set => P.ForegroundColor = value; get => P.ForegroundColor; }
		[Parameter] public Xamarin.Forms.Binding BindForegroundColor { set { P.SetBinding(Xamarin.Forms.Span.ForegroundColorProperty, value); } }
		[Parameter] public System.String Text { set => P.Text = value; get => P.Text; }
		[Parameter] public Xamarin.Forms.Binding BindText { set { P.SetBinding(Xamarin.Forms.Span.TextProperty, value); } }
		[Parameter] public Xamarin.Forms.FontAttributes FontAttributes { set => P.FontAttributes = value; get => P.FontAttributes; }
		[Parameter] public Xamarin.Forms.Binding BindFontAttributes { set { P.SetBinding(Xamarin.Forms.Span.FontAttributesProperty, value); } }
		[Parameter] public System.String FontFamily { set => P.FontFamily = value; get => P.FontFamily; }
		[Parameter] public Xamarin.Forms.Binding BindFontFamily { set { P.SetBinding(Xamarin.Forms.Span.FontFamilyProperty, value); } }
		[Parameter] public System.Double FontSize { set => P.FontSize = value; get => P.FontSize; }
		[Parameter] public Xamarin.Forms.Binding BindFontSize { set { P.SetBinding(Xamarin.Forms.Span.FontSizeProperty, value); } }
		[Parameter] public Xamarin.Forms.TextDecorations TextDecorations { set => P.TextDecorations = value; get => P.TextDecorations; }
		[Parameter] public Xamarin.Forms.Binding BindTextDecorations { set { P.SetBinding(Xamarin.Forms.Span.TextDecorationsProperty, value); } }
		[Parameter] public System.Double LineHeight { set => P.LineHeight = value; get => P.LineHeight; }
		[Parameter] public Xamarin.Forms.Binding BindLineHeight { set { P.SetBinding(Xamarin.Forms.Span.LineHeightProperty, value); } }
		[Parameter] public System.String AutomationId { set => P.AutomationId = value; get => P.AutomationId; }
		[Parameter] public Xamarin.Forms.Binding BindAutomationId { set { P.SetBinding(Xamarin.Forms.Span.AutomationIdProperty, value); } }
		[Parameter] public System.String ClassId { set => P.ClassId = value; get => P.ClassId; }
		[Parameter] public Xamarin.Forms.Binding BindClassId { set { P.SetBinding(Xamarin.Forms.Span.ClassIdProperty, value); } }
		[Parameter] public System.String StyleId { set => P.StyleId = value; get => P.StyleId; }
		[Parameter] public Xamarin.Forms.Element Parent { set => P.Parent = value; get => P.Parent; }
		[Parameter] public Xamarin.Forms.IEffectControlProvider EffectControlProvider { set => P.EffectControlProvider = value; get => P.EffectControlProvider; }
		[Parameter] public System.Object BindingContext { set => P.BindingContext = value; get => P.BindingContext; }
		[Parameter] public Xamarin.Forms.Binding BindBindingContext { set { P.SetBinding(Xamarin.Forms.Span.BindingContextProperty, value); } }
    }
}
