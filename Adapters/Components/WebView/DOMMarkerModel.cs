using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    /// <summary>
    /// Indicates the boundary of a component or renderfragment, doesnt generate any dom by itself
    /// </summary>
    public class DOMMarkerModel:DOMElementModel
    {
        public DOMMarkerModel(int id, int sequenceNumber, int parentId, string label):base(id, sequenceNumber, parentId, label, DOMType.Marker)
        {
        }

        public override string ToString()
        {
            return $"<!--Start {Tag}-->{string.Join("", Children.OrderBy(c=> c.Value.SequenceNumber).Select(c => c.Value.ToString()))}<!--End {Tag}-->";
        }
    }
}
