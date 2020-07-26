using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    public class ShellContentNativeElementAdapter : INativeAdapter<XF.ShellContent>
    {
        public bool Add(XF.ShellContent view, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            switch (child)
            {
                case ContentPage page:
                    view.Content = page;
                    break;
                case TemplatedPage tpage:
                    view.Content = tpage;
                    break;
                case XRF.DataTemplate template:
                    view.ContentTemplate = template.P;
                    break;
                default:
                    if (@throw)
                        throw new InvalidOperationException($"{view.GetType()} supports only ChildContent of type {typeof(XF.ContentPage)} or  {typeof(XF.TemplatedPage)}");
                    return false;
            }
            return true;
        }

        public bool Remove(ShellContent view, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            throw new NotImplementedException();
        }

        public bool Replace(ShellContent view, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            return Add(view, -1, newChild, rootAdapter, @throw);
        }
    }
}
