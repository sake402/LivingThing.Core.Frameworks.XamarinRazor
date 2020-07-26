using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class DOMBuilder : IDOMBuilder
    {
        Dictionary<int, DOMModel> doms = new Dictionary<int, DOMModel>();
        List<DOMModel> patches = new List<DOMModel>();
        DOMMarkerModel rootDOM = new DOMMarkerModel(-1, -1, -1, null);
        public DOMElementModel DOM => rootDOM;
        Dictionary<int, EventCallback> events = new Dictionary<int, EventCallback>();

        int GetId(IEnumerable<int> paths)
        {
            return string.Join("-", paths).GetHashCode();
        }

        int id = 1;
        int NextId()
        {
            int nextId = id;
            id++;
            return nextId;
        }

        public int CreateElement(int parentId, int elementSequence, string elementName)
        {
            int id = parentId + elementSequence + 1;
            var dom = new DOMElementModel(id, elementSequence, parentId, elementName);
            if (parentId < 0)
                rootDOM.Children[id] = dom;
            else
                (doms[parentId] as DOMElementModel).Children[id] = dom;
            doms[id] = dom;
            if (!patches.Contains(dom))
                patches.Add(dom);
            return id;
        }

        int markerRegionId = 8192;
        public int CreateMarkerElement(int parentId, int elementSequence, string label)
        {
            int id = markerRegionId;// + parentId + elementSequence + 1;
            markerRegionId += 8192;
            var dom = new DOMMarkerModel(id, elementSequence, parentId, label);
            if (parentId < 0)
                rootDOM.Children[id] = dom;
            else
                (doms[parentId] as DOMElementModel).Children[id] = dom;
            doms[id] = dom;
            if (!patches.Contains(dom))
                patches.Add(dom);
            return id;
        }

        public int InsertMarkup(int parentId, int markupSequence, string markup)
        {
            int id = parentId + markupSequence + 1;
            var dom = new DOMMarkupModel(id, markupSequence, parentId, markup);
            if (parentId < 0)
                rootDOM.Children[id] = dom;
            else
                (doms[parentId] as DOMElementModel).Children[id] = dom;
            doms[id] = dom;
            if (!patches.Contains(dom))
                patches.Add(dom);
            return id;
        }

        public int InsertText(int parentId, int textSequence, string text)
        {
            int id = parentId + textSequence + 1;
            var dom = new DOMTextModel(id, textSequence, parentId, text);
            if (parentId < 0)
                rootDOM.Children[id] = dom;
            else
            {
                (doms[parentId] as DOMElementModel).Children[id] = dom;
            }
            doms[id] = dom;
            if (!patches.Contains(dom))
                patches.Add(dom);
            return id;
        }

        public void RemoveAt(int parentId, int index)
        {
            IDictionary<int, DOMModel> target;
            if (parentId < 0)
                target = rootDOM.Children;
            else
                target = (doms[parentId] as DOMElementModel).Children;
            var element = target.ElementAt(index);
            patches.Add(new DOMModel(element.Value.Id, -1, parentId, DOMType.Remove));
            target.Remove(element.Key);
        }

        public void RemoveAttribute(int elementId, int attributeSequence, string key)
        {
            var dom = doms[elementId] as DOMElementModel;
            dom.Attributes.Remove(key);
            if (!patches.Contains(dom))
                patches.Add(dom);
        }

        public int SetAttribute(int elementId, int attributeSequence, string key, object value)
        {
            var dom = doms[elementId] as DOMElementModel;
            dom.Attributes[key] = value;
            if (!patches.Contains(dom))
                patches.Add(dom);
            return elementId;
        }

        public int SetEvent(int elementId, int attributeSequence, string name, EventCallback value, string propertyBound)
        {
            int eventId = elementId + attributeSequence + 1;
            events[eventId] = value;
            var target = doms[elementId] as DOMElementModel;
            target.Events[name] = new DOMEventModel(eventId, -1, elementId, !string.IsNullOrEmpty(propertyBound) ? ("/" + propertyBound) : "");
            //patches.Add(target);
            return eventId;
        }

        public async void DispatchEvent(int eventId, string eventParam)
        {
            var eventCallBack = events[eventId];
            await eventCallBack.InvokeAsync(this);
        }

        public IEnumerable<DOMModel> GetPatches()
        {
            var newModels = patches.Select(p =>
            {
                if (p is DOMElementModel elementModel)
                {
                    var m = new DOMElementModel(elementModel.Id, elementModel.SequenceNumber, elementModel.ParentId, elementModel.Tag);
                    foreach(var att in elementModel.Attributes)
                    {
                        m.Attributes.Add(att.Key, att.Value);
                    }
                    return m;
                }
                return p;
            }).ToArray();
            patches.Clear();
            return newModels;
        }

        public int Child(int elementId, int index)
        {
            DOMElementModel elementModel;
            if (elementId < 0)
                elementModel = rootDOM;
            else
                elementModel = doms[elementId] as DOMElementModel;
            return elementModel[index].Id;
        }

        public int Parent(int elementId)
        {
            DOMElementModel elementModel;
            if (elementId < 0)
                elementModel = rootDOM;
            else
                elementModel = doms[elementId] as DOMElementModel;
            return elementModel.ParentId;
        }

        public override string ToString()
        {
            return rootDOM.ToString();
        }
    }
}
