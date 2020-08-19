using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class DOMMarkupModel:DOMModel
    {
        public DOMMarkupModel(int id, int sequenceNumber, int parentId, string markup):base(id, sequenceNumber, parentId, DOMType.Markup)
        {
            Markup = markup;
        }

        public string Markup { get; set; }
        public override string ToString()
        {
            return Markup;
        }
    }
}
