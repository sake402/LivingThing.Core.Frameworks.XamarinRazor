using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class DOMElementModel : DOMModel
    {
        private static readonly HashSet<string> _selfClosingElements = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "meta", "param", "source", "track", "wbr"
        };

        public DOMElementModel(int id, int sequenceNumber, int parentId, string tag) : base(id, sequenceNumber, parentId, DOMType.Element)
        {
            Tag = tag;
        }

        protected DOMElementModel(int id, int sequenceNumber, int parentId, string tag, DOMType type) : base(id, sequenceNumber, parentId, type)
        {
            Tag = tag;
        }

        public string Tag { get; }
        public Dictionary<string, DOMEventModel> Events { get; } = new Dictionary<string, DOMEventModel>();
        public Dictionary<string, object> Attributes { get; } = new Dictionary<string, object>();
        public Dictionary<int, DOMModel> Children { get; } = new Dictionary<int, DOMModel>();

        IEnumerable<DOMModel> OwnChildren
        {
            get
            {
                return Children.Values./*OrderBy(d => d.SequenceNumber).*/SelectMany<DOMModel, DOMModel>(c =>
                 {
                     if (c is DOMMarkerModel dom)
                     {
                         return dom.OwnChildren;//Children.OrderBy(d => d.SequenceNumber);
                     }
                     return new DOMModel[] { c };
                 });
            }
        }
        public DOMModel this[int index]
        {
            get
            {
                try
                {
                    return OwnChildren.ElementAt(index);
                }
                catch
                {
                    throw;
                }
            }
        }

        public override string ToString()
        {
            return $"<{Tag + (Attributes.Count > 0 ? " " : "")}{string.Join(" ", Attributes.Select(a => $"{a.Key}=\"{a.Value}\""))}>{string.Join("", Children.OrderBy(c=> c.Value.SequenceNumber).Select(c => c.Value.ToString()))}</{Tag}>";
        }

        public bool ShouldSerializeEvents()
        {
            return Events.Count > 0;
        }

        public bool ShouldSerializeChildren()
        {
            return Children.Count > 0;
        }

        public bool ShouldSerializeAttributes()
        {
            return Attributes.Count > 0;
        }
    }
}
