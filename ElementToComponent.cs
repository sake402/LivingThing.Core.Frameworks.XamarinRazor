using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public class ElementToComponent<TElement> : ComponentToXamarinBridge<TElement, ComponentBase> where TElement : Element, new()
    {
        public ElementToComponent()
        {
        }

        public ElementToComponent(TElement _element) : base(_element)
        {
        }

        [Parameter] public TElement NativeElement { set { xamarinElement = value; } }
    }
}
