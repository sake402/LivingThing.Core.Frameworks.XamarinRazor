using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public enum DOMType { Text, Markup, Element, Marker, Event, Remove }
    public class DOMModel
    {
        public DOMModel(int id, int sequenceNumber, int parentId, DOMType type)
        {
            Id = id;
            SequenceNumber = sequenceNumber;
            ParentId = parentId;
            Type = type;
        }

        public int Id { get; }
        public int SequenceNumber { get; }
        public int ParentId { get; }
        public DOMType Type { get; }
    }
}
