using System;
using System.Collections.Generic;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class DOMTextModel:DOMModel
    {
        public DOMTextModel(int id, int sequenceNumber, int parentId, string text):base(id, sequenceNumber, parentId, DOMType.Text)
        {
            Text = text;
        }

        public string Text { get; }
        public override string ToString()
        {
            return Text;
        }
    }
}
