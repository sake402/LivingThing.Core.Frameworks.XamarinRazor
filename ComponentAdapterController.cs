using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives;
using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components;
using Microsoft.Extensions.Logging;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    internal class ComponentAdapterController : IDisposable, IComponentAdapterController
    {
        public ComponentAdapterController(RazorComponentRenderer renderer, IComponent component, object rootElement, ComponentAdapterController parent = null)
        {
            Renderer = renderer;
            Component = component;
            RootElement = rootElement;
            Parent = parent;
            //if (parent != null)
            //{
            //    parent.Children.Add(this);
            //}
        }
        RazorComponentRenderer Renderer { get; }
        object rootElement;
        TaskCompletionSource<VisualElement> visualElementTask = new TaskCompletionSource<VisualElement>();
        public object RootElement
        {
            get => rootElement;
            set
            {
                rootElement = value;
                if (value is VisualElement vel)
                {
                    visualElementTask.SetResult(vel);
                }
            }
        }

        public Task<VisualElement> VisualElement => visualElementTask.Task;

        public ComponentAdapterController Parent { get; }
        IComponentAdapterController IComponentAdapterController.Parent => Parent;

        public IServiceProvider ServiceProvider => Renderer.ServiceProvider;

        //IList<ComponentAdapter> Children { get; } = new List<ComponentAdapter>();
        IComponent Component { get; }

        Dictionary<int, object> SiblingAtIndex = new Dictionary<int, object>();
        //void AddContent(XF.ContentView contentView, View view, int index)
        //{
        //    //if (contentView.Content == null)
        //    //    contentView.Content = view;
        //    //else
        //    {
        //        var stackLayout = contentView.Content as XF.StackLayout;
        //        if (stackLayout == null)
        //        {
        //            stackLayout = new XF.StackLayout();
        //            //stackLayout.Children.Add(contentView.Content);
        //        }
        //        stackLayout.Children.Insert(index, view);
        //        contentView.Content = stackLayout;
        //    }
        //}

        //void AddContent(XF.ContentPage page, View view, int index)
        //{
        //    //if (page.Content == null)
        //    //    page.Content = view;
        //    //else
        //    {
        //        var stackLayout = page.Content as XF.StackLayout;
        //        if (stackLayout == null)
        //        {
        //            stackLayout = new XF.StackLayout();
        //            //stackLayout.Children.Add(page.Content);
        //        }
        //        stackLayout.Children.Insert(index, view);
        //        page.Content = stackLayout;
        //    }
        //}

        //void AddContent(XF.Page page, int index)
        //{
        //    if (RootElement is XF.MultiPage<XF.Page> multiPage)
        //    {
        //        multiPage.Children.Insert(index, page);
        //    }
        //    else
        //    {
        //        throw new Exception($"Unhandled Parent Type {RootElement.GetType()}");
        //    }
        //}

        //void AddContent(View view, int index)
        //{
        //    if (RootElement is XF.ContentPage page)
        //    {
        //        AddContent(page, view, index);
        //    }
        //    else if (RootElement is XF.Layout<View> layout)
        //    {
        //        layout.Children.Insert(index, view);
        //    }
        //    else if (RootElement is XF.ContentView contentView)
        //    {
        //        AddContent(contentView, view, index);
        //    }
        //    else
        //    {
        //        //throw new Exception($"Unhandled Parent Type {RootElement.GetType()}");
        //    }
        //}
        //public Task<VisualElement> GetClosestVisualElement()
        //{
        //    if (RootElement is VisualElement vEl)
        //        return vEl;
        //    return Parent?.GetClosestVisualElement();
        //}        

        //void AddStyleSheet(params StyleSheet[] sheets)
        //{
        //    VisualElement _parentVisualElement= GetClosestVisualElement();
        //    if (_parentVisualElement != null)
        //    {
        //        foreach (var sheet in sheets)
        //        {
        //            // TODO: Add logic to ensure same resource isn't added multiple times
        //            if (sheet.Resource != null)
        //            {
        //                if (sheet.Assembly == null)
        //                {
        //                    throw new InvalidOperationException($"Specifying a '{nameof(sheet.Resource)}' property value '{sheet.Resource}' requires also specifying the '{nameof(sheet.Assembly)}' property to indicate the assembly containing the resource.");
        //                }
        //                var styleSheet = XF.StyleSheets.StyleSheet.FromResource(resourcePath: sheet.Resource, assembly: sheet.Assembly);
        //                _parentVisualElement.Resources.Add(styleSheet);
        //            }
        //            if (sheet.Text != null)
        //            {
        //                using var reader = new StringReader(sheet.Text);
        //                var styleSheet = XF.StyleSheets.StyleSheet.FromReader(reader);
        //                _parentVisualElement.Resources.Add(styleSheet);
        //            }
        //        }
        //    }
        //}

        INativeAdapter adapter;
        INativeAdapter Adapter
        {
            get
            {
                if (adapter != null)
                    return adapter;
                var adapters = Renderer.ServiceProvider.GetServices<INativeAdapter>();
                Type type;
                if (RootElement is ComponentToXamarinBridge bridge)
                {
                    type = bridge.Element.GetType();
                }
                else
                {
                    type = RootElement.GetType();
                }
                var typeLookup = typeof(INativeAdapter<>).MakeGenericType(type);
                var matchingAdapters = adapters.Where(a => typeLookup.IsAssignableFrom(a.GetType())).ToArray();
                if (matchingAdapters.Length == 0)
                {

                }
                return adapter = matchingAdapters[0];
            }
        }

        void AdapterAdd<TElement>(INativeAdapter<TElement> adapter, TElement to, int index, object child, bool @throw)
        {
            adapter.Add(to, index, child, this, @throw);
        }

        void AdapterReplace<TElement>(INativeAdapter<TElement> adapter, TElement from, object old, object @new, bool @throw)
        {
            adapter.Replace(from, old, @new, this, @throw);
        }

        void AdapterRemove<TElement>(INativeAdapter<TElement> adapter, TElement from, object child, bool @throw)
        {
            adapter.Remove(from, child, this, @throw);
        }

        public void Add(object element, int index, bool @throw = true)
        {
            if (RootElement != null)
            {
                object root;
                if (RootElement is ComponentToXamarinBridge bridge)
                {
                    root = bridge.Element;
                }
                else
                {
                    root = RootElement;
                }
                AdapterAdd((dynamic)Adapter, (dynamic)root, index, element, @throw);
            }
            SiblingAtIndex[index] = element;
        }

        public void Replace(object oldElement, object newElement, bool @throw = true)
        {
            if (RootElement != null)
            {
                object root;
                if (RootElement is ComponentToXamarinBridge bridge)
                {
                    root = bridge.Element;
                }
                else
                {
                    root = RootElement;
                }
                AdapterReplace((dynamic)Adapter, (dynamic)root, oldElement, newElement, @throw);
            }
            int index = Array.IndexOf(SiblingAtIndex.Values.ToArray(), oldElement);
            SiblingAtIndex[index] = newElement;
        }

        public void Remove(int index)
        {
            if (SiblingAtIndex.ContainsKey(index))
            {
                object root;
                if (RootElement is ComponentToXamarinBridge bridge)
                {
                    root = bridge.Element;
                }
                else
                {
                    root = RootElement;
                }
                AdapterRemove((dynamic)Adapter, (dynamic)root, SiblingAtIndex[index], false);
                SiblingAtIndex.Remove(index);
                for (int i = index + 1; ; i++)
                {
                    if (SiblingAtIndex.ContainsKey(i))
                    {
                        SiblingAtIndex[i - 1] = SiblingAtIndex[i];
                    }
                    else break;
                }
                if (SiblingAtIndex.Count > 0)
                {
                    SiblingAtIndex.Remove(SiblingAtIndex.Count - 1);
                }
            }
        }

        void Remove(object child)
        {
            int index = Array.IndexOf(SiblingAtIndex.Values.ToArray(), child);
            Remove(index);
        }

        IList<View> GetChildren()
        {
            if (RootElement is XF.ContentPage page)
            {
                return (page.Content as XF.StackLayout).Children;
            }
            else if (RootElement is XF.Layout<View> layout)
            {
                return layout.Children;
            }
            else if (RootElement is XF.ContentView contentView)
            {
                return (contentView.Content as XF.StackLayout).Children;
            }
            else
            {
                throw new InvalidOperationException($"Unhandled Parent Type {RootElement.GetType()}");
            }
        }

        IList<XF.Page> GetPageChildren()
        {
            if (RootElement is XF.MultiPage<XF.Page> multiPage)
            {
                return multiPage.Children;
            }
            else
            {
                throw new InvalidOperationException($"Unhandled Parent Type {RootElement.GetType()}");
            }
        }

        void SetText(View view, string text)
        {
            if (view is XF.Label label)
            {
                label.Text = text;
            }
            else
            {
                throw new InvalidOperationException($"Unhandled Text Type {view.GetType()}");
            }
        }

        class ChildContentValue
        {
            public string Value { get; set; }
        }

        object Adapt<TComponent>(IComponentAdapter<TComponent> adapter, TComponent component) where TComponent : IComponent
        {
            return adapter.Adapt(component, this);
        }

        static Dictionary<Type, IComponentAdapter> ComponentAdapters = new Dictionary<Type, IComponentAdapter>();

        object UnWrap(IComponent component)
        {
            IComponentAdapter bestAdapter = null;
            var componentType = component.GetType();
            if (ComponentAdapters.TryGetValue(componentType, out bestAdapter) == false)
            {
                var adapters = Renderer.ServiceProvider.GetServices<Adapters.Components.IComponentAdapter>();
                var typeLookup = typeof(IComponentAdapter<>).MakeGenericType(component.GetType());
                var matchingAdapters = adapters.Where(a => typeLookup.IsAssignableFrom(a.GetType())).ToArray();
                //choose the best fit adapter
                Type bestType = null;
                foreach (var adapter in matchingAdapters)
                {
                    var implementedInterface = adapter.GetType().GetInterfaces().First(it => typeof(Adapters.Components.IComponentAdapter).IsAssignableFrom(it) && it.IsGenericType);
                    var nativeType = implementedInterface.GetGenericArguments()[0];
                    if (bestType == null || bestType.IsAssignableFrom(nativeType))
                    {
                        bestType = nativeType;
                        bestAdapter = adapter;
                    }
                }
                ComponentAdapters[componentType] = bestAdapter;
            }
            return Adapt((dynamic)bestAdapter, (dynamic)component);
        }

        Dictionary<int, string> TextChildContent = new Dictionary<int, string>();
        public void Apply(RenderTreeDiff tree, RenderBatch batch)
        {
            //List<int> removedIndex = new List<int>();
            //List<View> 
            //List<StyleSheet> deferedStyleSheet = new List<StyleSheet>();
            foreach (var edit in tree.Edits)
            {
                switch (edit.Type)
                {
                    case RenderTreeEditType.PrependFrame:
                        {
                            var frame = batch.ReferenceFrames.Array[edit.ReferenceFrameIndex];
                            switch (frame.FrameType)
                            {
                                case RenderTreeFrameType.Component:
                                    object element = UnWrap(frame.Component);
                                    if (RootElement == null && (element is XF.Element || element is BridgeComponentBase))
                                    {
                                        RootElement = element;
                                    }
                                    if (element == null || RootElement != element)
                                    {
                                        Add(element, edit.SiblingIndex, element != null);
                                    }
                                    var childAdapter = new ComponentAdapterController(Renderer, frame.Component, element, this);
                                    Renderer.Adapters[frame.ComponentId] = childAdapter;
                                    break;
                                case RenderTreeFrameType.Text:
                                    var componentType = Component.GetType();
                                    var textProperty = componentType.GetProperty("Text");
                                    if (textProperty != null)
                                    {
                                        TextChildContent[frame.Sequence] = frame.TextContent;
                                        var value = string.Join("", TextChildContent.Values);
                                        textProperty.SetValue(Component, value);
                                    }
                                    else
                                    {
                                        var trimmedText = frame.TextContent.Trim();
                                        Add(!string.IsNullOrEmpty(trimmedText) ? new XF.Label() { Text = frame.TextContent.Trim() } : null, edit.SiblingIndex, false);
                                    }
                                    break;
                                case RenderTreeFrameType.Markup: //convert markups to label
                                    //if (!string.IsNullOrEmpty(frame.TextContent.Trim()))
                                    {
                                        var trimmedText = frame.MarkupContent.Trim();
                                        Add(!string.IsNullOrEmpty(trimmedText) ? new XF.Label() { Text = frame.MarkupContent.Trim() } : null, edit.SiblingIndex, false);
                                    }
                                    //else
                                    //{
                                    //    AddContent(new XF.Span() { Text = frame.MarkupContent.Trim() }, edit.SiblingIndex);
                                    //}
                                    break;
                                default:
                                    throw new NotImplementedException($"Invalid Frame type: {frame.FrameType}");
                            }
                        }
                        break;
                    case RenderTreeEditType.UpdateText:
                        {
                            var frame = batch.ReferenceFrames.Array[edit.ReferenceFrameIndex];
                            var componentType = Component.GetType();
                            var textProperty = componentType.GetProperty("Text");
                            if (textProperty != null)
                            {
                                TextChildContent[frame.Sequence] = frame.TextContent;
                                var value = string.Join("", TextChildContent.Values);
                                textProperty.SetValue(Component, value);
                            }
                            else
                            {
                                var children = GetChildren();
                                var sibling = children[edit.SiblingIndex];
                                SetText(sibling, frame.TextContent);
                            }
                        }
                        break;
                    case RenderTreeEditType.RemoveFrame:
                        {
                            Remove(edit.SiblingIndex);
                            ////if (!removedIndex.Contains(edit.SiblingIndex))
                            //{
                            //    var children = GetChildren();
                            //    children.RemoveAt(edit.SiblingIndex);
                            //}
                        }
                        break;
                    case RenderTreeEditType.UpdateMarkup:
                        {

                        }
                        break;
                    //case RenderTreeEditType.SetAttribute:
                    //    break;
                    //case RenderTreeEditType.RemoveAttribute:
                    //    break;
                    //case RenderTreeEditType.UpdateText:
                    //    break;
                    //case RenderTreeEditType.StepIn:
                    //    break;
                    //case RenderTreeEditType.StepOut:
                    //    break;
                    //case RenderTreeEditType.PermutationListEntry:
                    //case RenderTreeEditType.PermutationListEnd:
                    default:
                        throw new NotImplementedException($"Invalid edit type: {edit.Type}");
                }
            }
            //force webview to update too
            if (RootElement is XRF.WebView webView)
            {
                webView.StateChanged();
            }
        }

        public void Dispose()
        {
            //if (Parent != null && RootElement != null)
            //{
            //    Parent.Remove(RootElement);
            //}
            //if (RootElement is Element view)
            //{
            //    if (view.Parent != null)
            //    {
            //        view.Rem
            //    }
            //}
            if (Component is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
