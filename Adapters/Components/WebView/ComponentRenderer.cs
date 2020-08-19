using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class ComponentRenderer:IDisposable
    {
        public ComponentRenderer(IComponent component, WebViewRenderer webViewRenderer, ComponentRenderer parent = null)
        {
            Component = component;
            WebViewRenderer = webViewRenderer;
            Parent = parent;
            InitialNode = parent?.CurrentNode ?? -1;
            if (parent != null)
            {
                parent.Children.Add(this);
                //foreach(var sequence in parent.Sequences.Reverse())
                //{
                //    Sequences.Push(sequence);
                //}
            }
        }

        //public ComponentRenderer(int elementId, WebViewRenderer webViewRenderer, ComponentRenderer parent = null)
        //{
        //    ElementId = elementId;
        //    WebViewRenderer = webViewRenderer;
        //    Parent = parent;
        //    if (parent != null)
        //        parent.Children.Add(this);
        //}

        int Depth
        {
            get
            {
                int depth = 0;
                ComponentRenderer current = this;
                while (current != null)
                {
                    depth++;
                    current = current.Parent;
                }
                return depth;
            }
        }

        IComponent Component { get; }
        //Stack<int> Sequences { get; } = new Stack<int>();
        //int CurrentElementId
        //{
        //    get
        //    {
        //        if (Elements.Count > 0)
        //            return Elements.Peek();
        //        return -1;
        //    }
        //}
        //int ElementId { get; }
        WebViewRenderer WebViewRenderer { get; }
        ComponentRenderer Parent { get; }
        List<ComponentRenderer> Children { get; } = new List<ComponentRenderer>();
        //Dictionary<int, int[]> SequencePath { get; } = new Dictionary<int, int[]>();
        int InitialNode { get; } = -1;
        int CurrentNode { get; set; } = -1;

        void ProcessTree(RenderTreeEdit edit, RenderBatch batch, int startIndex, int subLength)
        {
            for (int i = 0; i < subLength; i++)
            {
                int currentIndex = startIndex + i;
                var frame = batch.ReferenceFrames.Array[currentIndex];
                switch (edit.Type)
                {
                    case RenderTreeEditType.PrependFrame:
                        {
                            switch (frame.FrameType)
                            {
                                case RenderTreeFrameType.Component:
                                    {
                                        CurrentNode = WebViewRenderer.DOMBuilder.CreateMarkerElement(CurrentNode, frame.Sequence, frame.Component.GetType().Name);
                                        //Sequences.Push(frame.Sequence);
                                        var childRenderer = new ComponentRenderer(frame.Component, WebViewRenderer, this);
                                        WebViewRenderer.Renderers[frame.ComponentId] = childRenderer;
                                        //we dont need to process the subtree of components as the Renderer will process it again
                                        //ProcessTree(edit, batch, currentIndex + 1, frame.ElementSubtreeLength - 1);
                                        i += frame.ComponentSubtreeLength - 1;
                                        //Sequences.Pop();
                                        CurrentNode = WebViewRenderer.DOMBuilder.Parent(CurrentNode);
                                    }
                                    break;
                                case RenderTreeFrameType.Element:
                                    {
                                        CurrentNode = WebViewRenderer.DOMBuilder.CreateElement(CurrentNode, frame.Sequence, frame.ElementName);
                                        //Sequences.Push(frame.Sequence);
                                        ProcessTree(edit, batch, currentIndex + 1, frame.ElementSubtreeLength - 1);
                                        i += frame.ElementSubtreeLength - 1;
                                        //Sequences.Pop();
                                        CurrentNode = WebViewRenderer.DOMBuilder.Parent(CurrentNode);
                                    }
                                    break;
                                case RenderTreeFrameType.Attribute:
                                    {
                                        if (frame.AttributeValue is EventCallback callback)
                                        {
                                            WebViewRenderer.DOMBuilder.SetEvent(CurrentNode, frame.Sequence, frame.AttributeName, callback, frame.AttributeEventUpdatesAttributeName);
                                        }
                                        else
                                        {
                                            WebViewRenderer.DOMBuilder.SetAttribute(CurrentNode, frame.Sequence, frame.AttributeName, frame.AttributeValue);
                                        }
                                    }
                                    break;
                                case RenderTreeFrameType.Text:
                                    WebViewRenderer.DOMBuilder.InsertText(CurrentNode, frame.Sequence, frame.TextContent);
                                    break;
                                case RenderTreeFrameType.Markup:
                                    {
                                        WebViewRenderer.DOMBuilder.InsertMarkup(CurrentNode, frame.Sequence, frame.MarkupContent);
                                    }
                                    break;
                                case RenderTreeFrameType.Region:
                                    {
                                        CurrentNode = WebViewRenderer.DOMBuilder.CreateMarkerElement(CurrentNode, frame.Sequence, frame.AttributeName);
                                        //Sequences.Push(frame.Sequence);
                                        ProcessTree(edit, batch, currentIndex + 1, frame.RegionSubtreeLength - 1);
                                        i += frame.RegionSubtreeLength - 1;
                                        //Sequences.Pop();
                                        CurrentNode = WebViewRenderer.DOMBuilder.Parent(CurrentNode);
                                    }
                                    break;
                                case RenderTreeFrameType.ElementReferenceCapture:
                                    ElementReference reference = new ElementReference(CurrentNode.ToString());
                                    //WebViewRenderer.DOMBuilder.Reference();
                                    frame.ElementReferenceCaptureAction(reference);
                                    break;
                                case RenderTreeFrameType.None:
                                    break;
                                default:
                                    throw new NotImplementedException($"Invalid Frame type: {frame.FrameType}");
                            }
                        }
                        break;
                    case RenderTreeEditType.UpdateText:
                        {
                            WebViewRenderer.DOMBuilder.UpdateText(CurrentNode, frame.Sequence, frame.TextContent);
                        }
                        break;
                    case RenderTreeEditType.RemoveFrame:
                        {
                            WebViewRenderer.DOMBuilder.RemoveAt(CurrentNode, edit.SiblingIndex);
                        }
                        break;
                    case RenderTreeEditType.UpdateMarkup:
                        {
                            WebViewRenderer.DOMBuilder.UpdateMarkup(CurrentNode, frame.Sequence, frame.TextContent);
                        }
                        break;
                    case RenderTreeEditType.SetAttribute:
                        {
                            var node = WebViewRenderer.DOMBuilder.Child(CurrentNode, edit.SiblingIndex);
                            if (frame.AttributeValue is EventCallback callback)
                            {
                                WebViewRenderer.DOMBuilder.SetEvent(node, frame.Sequence, frame.AttributeName, callback, frame.AttributeEventUpdatesAttributeName);
                            }
                            else
                            {
                                WebViewRenderer.DOMBuilder.SetAttribute(node, frame.Sequence, frame.AttributeName, frame.AttributeValue);
                            }
                            //WebViewRenderer.DOMManager.SetAttribute(CurrentNode, frame.Sequence, frame.AttributeName, frame.AttributeValue);
                        }
                        break;
                    case RenderTreeEditType.RemoveAttribute:
                        {
                            WebViewRenderer.DOMBuilder.RemoveAttribute(CurrentNode, frame.Sequence, frame.AttributeName);
                        }
                        break;
                    case RenderTreeEditType.StepIn:
                        CurrentNode = WebViewRenderer.DOMBuilder.Child(CurrentNode, edit.SiblingIndex);
                        break;
                    case RenderTreeEditType.StepOut:
                        CurrentNode = WebViewRenderer.DOMBuilder.Parent(CurrentNode);
                        break;
                    case RenderTreeEditType.PermutationListEntry:
                    case RenderTreeEditType.PermutationListEnd:
                    default:
                        throw new NotImplementedException($"Invalid edit type: {edit.Type}");
                }
            }
        }

        public void Apply(RenderTreeDiff tree, RenderBatch batch)
        {
            //List<int> removedIndex = new List<int>();
            //List<View> 
            //List<StyleSheet> deferedStyleSheet = new List<StyleSheet>();
            CurrentNode = InitialNode;
            foreach (var edit in tree.Edits)
            {
                var frame = batch.ReferenceFrames.Array[edit.ReferenceFrameIndex];
                ProcessTree(edit, batch, edit.ReferenceFrameIndex, edit.Type == RenderTreeEditType.PrependFrame ? (frame.ElementSubtreeLength == 0 ? 1 : frame.ElementSubtreeLength) :1);
                //ProcessTree(edit, batch, edit.ReferenceFrameIndex, frame.ElementSubtreeLength == 0 ? 1 : frame.ElementSubtreeLength);
                //int subtreeIndex = 0;
                //do
                //{
                //    switch (edit.Type)
                //    {
                //        case RenderTreeEditType.PrependFrame:
                //            {
                //                switch (frame.FrameType)
                //                {
                //                    case RenderTreeFrameType.Component:
                //                        {
                //                            var childRenderer = new ComponentRenderer(frame.Component, WebViewRenderer, this);
                //                            WebViewRenderer.Renderers[frame.ComponentId] = childRenderer;
                //                        }
                //                        break;
                //                    case RenderTreeFrameType.Element:
                //                        {
                //                            WebViewRenderer.DOMManager.CreateElement(Sequences.ToArray(), frame.Sequence, frame.ElementName);
                //                            Sequences.Push(frame.Sequence);
                //                        }
                //                        break;
                //                    case RenderTreeFrameType.Attribute:
                //                        {
                //                            WebViewRenderer.DOMManager.SetAttribute(Sequences.ToArray(), frame.AttributeName, frame.AttributeValue);
                //                        }
                //                        break;
                //                    case RenderTreeFrameType.Text:
                //                        WebViewRenderer.DOMManager.InsertText(Sequences.ToArray(), frame.Sequence, frame.TextContent);
                //                        break;
                //                    case RenderTreeFrameType.Markup: 
                //                        WebViewRenderer.DOMManager.InsertMarkup(Sequences.ToArray(), frame.Sequence, frame.MarkupContent);
                //                        break;
                //                    case RenderTreeFrameType.Region:
                //                        Sequences.Push(frame.Sequence);
                //                        int sequenceSubTrees = frame.RegionSubtreeLength;
                //                        break;
                //                    default:
                //                        throw new NotImplementedException($"Invalid Frame type: {frame.FrameType}");
                //                }
                //            }
                //            break;
                //        case RenderTreeEditType.UpdateText:
                //            {
                //                WebViewRenderer.DOMManager.InsertText(Sequences.ToArray(), frame.Sequence, frame.TextContent);
                //            }
                //            break;
                //        case RenderTreeEditType.RemoveFrame:
                //            {
                //                WebViewRenderer.DOMManager.RemoveAt(Sequences.ToArray(), edit.SiblingIndex);
                //            }
                //            break;
                //        case RenderTreeEditType.UpdateMarkup:
                //            {
                //                WebViewRenderer.DOMManager.InsertText(Sequences.ToArray(), frame.Sequence, frame.TextContent);
                //            }
                //            break;
                //        case RenderTreeEditType.SetAttribute:
                //            {
                //                WebViewRenderer.DOMManager.SetAttribute(Sequences.ToArray(), frame.AttributeName, frame.AttributeValue);
                //            }
                //            break;
                //        case RenderTreeEditType.RemoveAttribute:
                //            {
                //                WebViewRenderer.DOMManager.RemoveAttribute(Sequences.ToArray(), frame.AttributeName);
                //            }
                //            break;
                //        case RenderTreeEditType.StepIn:
                //            break;
                //        case RenderTreeEditType.StepOut:
                //            break;
                //        case RenderTreeEditType.PermutationListEntry:
                //        case RenderTreeEditType.PermutationListEnd:
                //        default:
                //            throw new NotImplementedException($"Invalid edit type: {edit.Type}");
                //    }
                //    subtreeIndex++;
                //    if (batch.ReferenceFrames.Array[edit.ReferenceFrameIndex].ElementSubtreeLength > subtreeIndex)
                //        continue;
                //    break;
                //} while (true);
            }
        }

        public void Dispose()
        {
            Parent.Children?.Remove(this);
        }
    }
}
