using LivingThing.Core.Frameworks.XamarinRazor.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components
{
    /// Dont process viewCell yet
    public class ViewCellComponentAdapter : IComponentAdapter<XRF.ViewCell>
    {
        public object Adapt(ViewCell component, IComponentAdapterController rootAdapter)
        {
            return component;
        }
    }
}
