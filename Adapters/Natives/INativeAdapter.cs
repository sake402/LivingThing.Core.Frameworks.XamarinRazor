using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    public interface INativeAdapter
    {

    }
    public interface INativeAdapter<in TNative>:INativeAdapter
    {
        bool Add(TNative view, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true);
        bool Replace(TNative view, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true);
        bool Remove(TNative view, object child, IComponentAdapterController rootAdapter, bool @throw = true);
    }
}
