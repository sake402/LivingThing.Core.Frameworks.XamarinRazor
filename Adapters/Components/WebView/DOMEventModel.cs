using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class DOMEventModel:DOMModel
    {
        public DOMEventModel(int id, int sequenceNumber, int parentId, string name):base(id, sequenceNumber, parentId, DOMType.Event )
        {
            Name = name;
        }

        public string Name { get; }
    }
}
