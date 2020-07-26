using LivingThing.Core.Frameworks.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class WebViewRenderer : Renderer
    {
        internal IDOMBuilder DOMBuilder { get; } = new DOMBuilder();
        internal Dictionary<int, ComponentRenderer> Renderers { get; } = new Dictionary<int, ComponentRenderer>();
        XRF.WebView WebView { get; }
        private Exception _unhandledException;

        public WebViewRenderer(IServiceProvider serviceProvider, ILoggerFactory loggerFactory, XRF.WebView webView) : base(serviceProvider, loggerFactory)
        {
            WebView = webView;
        }

        public Task<string> AddComponent<T>(Action<T> parameterSetter)
        {
            return AddComponent(typeof(T), (o) => parameterSetter?.Invoke((T)o));
        }

        public async Task<string> AddComponent(Type componentType, Action<object> parameterSetter)
        {
            ComponentRenderer adapter = null;
            await Dispatcher.InvokeAsync(async () =>
            {
            var component = InstantiateComponent(componentType);
            var componentId = AssignRootComponentId(component);
            parameterSetter?.Invoke(component);

            adapter = new ComponentRenderer(component, this);
            Renderers[componentId] = adapter;
                try
                {
                    await RenderRootComponentAsync(componentId).ConfigureAwait(false);
                }catch(Exception e)
                {

                }
            }).ConfigureAwait(false);
            return DOMBuilder.ToString();
        }

        public override Dispatcher Dispatcher { get; } = Dispatcher.CreateDefault();

        protected override void HandleException(Exception exception)
        {
            _unhandledException = exception;
        }

        bool firstUpdate = true;
        protected override Task UpdateDisplayAsync(in RenderBatch renderBatch)
        {
            foreach (var updatedComponent in renderBatch.UpdatedComponents.Array.Take(renderBatch.UpdatedComponents.Count))
            {
                var adapter = Renderers[updatedComponent.ComponentId];
                adapter.Apply(updatedComponent, renderBatch);
            }
            foreach (var updatedComponent in renderBatch.DisposedComponentIDs.Array.Take(renderBatch.DisposedComponentIDs.Count))
            {
                Renderers[updatedComponent].Dispose();
                Renderers.Remove(updatedComponent);
            }
            string json;
            if (firstUpdate)
            {
                json = new[] { DOMBuilder.DOM }.Serialize();
                DOMBuilder.GetPatches(); //clear pathches
            }
            else
            {
                var patches = DOMBuilder.GetPatches();
                json = patches.Serialize();
            }
            Task.Run(async () =>
            {
                if (firstUpdate)
                {
                    await Task.Delay(30000);
                }
                var script = $"window.webView.update({json})";
                await Device.InvokeOnMainThreadAsync(() => WebView.P.EvaluateJavaScriptAsync(script));
                firstUpdate = false;
            });
            //var json = JsonSerializer.Serialize<object>(patches, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreReadOnlyProperties = false });
            //var script = $"window.webView.update({json})";
            //WebView.P.EvaluateJavaScriptAsync(script);
            return Task.CompletedTask;
        }

        public void DispatchAndAssertNoSynchronousErrors(Action callback)
        {
            Dispatcher.InvokeAsync(callback).Wait();
            AssertNoSynchronousErrors();
        }

        private void AssertNoSynchronousErrors()
        {
            if (_unhandledException != null)
            {
                ExceptionDispatchInfo.Capture(_unhandledException).Throw();
            }
        }
    }
}
