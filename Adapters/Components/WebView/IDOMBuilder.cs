using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public interface IDOMBuilder
    {
        /// <summary>
        /// The root of this DOM
        /// </summary>
        DOMElementModel DOM { get; }
        /// <summary>
        /// Create a new HTMLElement within the parent identified by parentId
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="nodeId"></param>
        /// <param name="elementName"></param>
        int CreateElement(int parentId, int elementSequence, string elementName);
        /// <summary>
        /// Create a marker to indicate the entry point for a Component/RenderFragment
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="nodeId"></param>
        /// <param name="elementName"></param>
        int CreateMarkerElement(int parentId, int elementSequence, string label);
        /// <summary>
        /// Adds text to a node identified by parentId, texts are sorted withing the parent acording to textSequence
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="textSequence"></param>
        /// <param name="text"></param>
        int InsertText(int parentId, int textSequence, string text);
        /// <summary>
        /// Adds markup to a node identified by parentId, texts are sorted withing the parent acording to textSequence
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="markupSequence"></param>
        /// <param name="text"></param>
        int InsertMarkup(int parentId, int markupSequence, string markup);
        /// <summary>
        /// Remove from a node identified by parentId, a content at index
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="index"></param>
        void RemoveAt(int parentId, int index);
        int SetAttribute(int elementId, int attributeSequence, string key, object value);
        void RemoveAttribute(int elementId, int attributeSequence, string key);
        int SetEvent(int elementId, int attributeSequence, string name, EventCallback value, string propertyBound);
        /// <summary>
        /// Notifies event subscriber
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="eventParam"></param>
        void DispatchEvent(int eventId, string eventParam);
        /// <summary>
        /// Get the Id of the nth child of element identified by elementSequence
        /// </summary>
        /// <param name="elementSequence"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        int Child(int elementSequence, int index);
        int Parent(int elementId);
        /// <summary>
        /// Get the models that need to be updated. Once this call is made, any new call will return empty array afterward until the dom is changed again
        /// </summary>
        /// <returns></returns>
        IEnumerable<DOMModel> GetPatches();
    }
}
