using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF = Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    public class ShellNativeElementAdapter : INativeAdapter<XF.Shell>
    {
        public bool Add(Shell view, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            switch (child)
            {
                case ShellSection shellSection:
                    view.Items.Add(shellSection);
                    break;
                case ShellContent shellContent:
                    view.Items.Add(shellContent);
                    break;
                case TemplatedPage page:
                    view.Items.Add(page);
                    break;
                case MenuItem menuItem:
                    view.Items.Add(menuItem);
                    break;
                case ShellItem shellItem:
                    view.Items.Add(shellItem);
                    break;
                default:
                    if (child is ComponentToXamarinBridge bridge && bridge.Property == nameof(Shell.FlyoutHeader))
                    {
                        view.FlyoutHeader = bridge.Element;
                        break;
                    }
                    if (@throw)
                        throw new InvalidOperationException($"{view.GetType()} does not supports only ChildContent of type {child?.GetType()}");
                    return false;
            }
            return true;
        }

        public bool Remove(Shell view, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            throw new NotImplementedException();
        }

        public bool Replace(Shell view, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            throw new NotImplementedException();
        }
    }
}
