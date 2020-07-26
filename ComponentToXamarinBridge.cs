using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    //Why this class
    //If you do @bind-Text in razor the generated code is AddAttribute("Text", new System.EventHandle
    //public struct EventHandler<T>
    //{
    //    public System.EventHandler<T> Handler { get; }

    //    public EventHandler(System.EventHandler<T> handler)
    //    {
    //        Handler = handler;
    //    }
    //}

    public abstract class ComponentToXamarinBridge : BridgeComponentBase
    {
        public abstract Element Element { get; }
    }

    public class ComponentToXamarinBridge<TXamarin, TComponent> : ComponentToXamarinBridge
        where TXamarin : Element, new()
        where TComponent : ComponentBase
    {

        public ComponentToXamarinBridge()
        {
        }

        public ComponentToXamarinBridge(TXamarin _element)
        {
            xamarinElement = _element;
        }

        protected TXamarin xamarinElement;
        public TXamarin P => xamarinElement ??= new TXamarin();

        public override Element Element => P;
        public override object Native => P;

        [Parameter]
        public string CssClass
        {
            set
            {
                var visualElement = P as NavigableElement;
                if (visualElement != null)
                {
                    var values = value.Split(new char[] { ' ', ',' });
                    visualElement.StyleClass = values.ToList();
                }
            }
        }

        //Add element to AbsoluteLayout
        [Parameter] public AbsoluteLayoutFlags AbsoluteLayoutFlags { set => AbsoluteLayout.SetLayoutFlags(P, value); }
        [Parameter] public Rectangle AbsoluteLayoutBounds { set => AbsoluteLayout.SetLayoutBounds(P, value); }
        //Add Element to Grid
        [Parameter] public int GridColumn { set => Grid.SetColumn(P, value); }
        [Parameter] public int GridColumnSpan { set => Grid.SetColumnSpan(P, value); }
        [Parameter] public int GridRow { set => Grid.SetRow(P, value); }
        [Parameter] public int GridrowSpan { set => Grid.SetRowSpan(P, value); }

    }


    public class ComponentToXamarinLayoutBridge<TXamarin, TComponent> : ComponentToXamarinBridge<TXamarin, TComponent> 
        where TXamarin : Layout,new()
        where TComponent : ComponentBase
    {

        public ComponentToXamarinLayoutBridge()
        {
        }

        public ComponentToXamarinLayoutBridge(TXamarin _element):base(_element)
        {
        }

        [Parameter] public IEnumerable BindableLayoutItemsSource { set => BindableLayout.SetItemsSource(P, value); }
        [Parameter] public DataTemplate BindableLayoutItemTemplate { set => BindableLayout.SetItemTemplate(P, value); }
        [Parameter] public DataTemplate BindableLayoutEmptyViewTemplate { set => BindableLayout.SetEmptyViewTemplate(P, value); }
        [Parameter] public DataTemplateSelector BindableLayoutTemplateSelector { set => BindableLayout.SetItemTemplateSelector(P, value); }
        [Parameter] public object BindableLayoutEmptyView { set => BindableLayout.SetEmptyView(P, value); }
    }
}