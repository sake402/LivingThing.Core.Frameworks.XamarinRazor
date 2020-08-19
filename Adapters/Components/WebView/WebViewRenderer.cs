using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using System.Web;
using System.Threading.Tasks;
using Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView
{
    public class WebViewRenderer : Renderer
    {
        internal IDOMBuilder DOMBuilder { get; }
        WebViewJsRuntime jsRuntime;
        internal Dictionary<int, ComponentRenderer> Renderers { get; } = new Dictionary<int, ComponentRenderer>();
        XRF.WebView WebView { get; }
        private Exception _unhandledException;

        public WebViewRenderer(IServiceProvider serviceProvider, ILoggerFactory loggerFactory, XRF.WebView webView) : base(serviceProvider, loggerFactory)
        {
            WebView = webView;
            jsRuntime = new WebViewJsRuntime(webView.P);
            DOMBuilder = new DOMBuilder(serviceProvider.GetService<IWebViewPathResolver>());
            WebView.P.Navigating += (s, e) =>
            {
                if (e.NavigationEvent == WebNavigationEvent.NewPage && e.Url == "file:///xamarinrazor/")
                {
                    //renderer.LoadHtml(dom, "file:///xamarinrazor");
                    UpdateDOM(true);
                    e.Cancel = true;
                }
                else if (e.Url.Contains("__event__"))
                {
                    var uri = new Uri(e.Url);
                    var query = uri.Query;
                    var collection = HttpUtility.ParseQueryString(query);
                    var eventId = int.Parse(collection["id"]);
                    var eventParam = HttpUtility.UrlDecode(collection["v"]);
                    DOMBuilder.DispatchEvent(eventId, eventParam);
                    e.Cancel = true;
                }
            };
            WebView.P.Navigated += (s, e) =>
            {
                UpdateDOM();
            };
        }

        public Task<string> Render()
        {
            return AddComponent<HtmlWrapper>((c) =>
            {
                c.Head = WebView.Head;
                c.ChildContent = WebView.ChildContent;
                c.BaseUrl = WebView.BaseUrl;
                WebView.Wrapper = c;
            });
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

        public async Task UpdateDOM(bool forceFirstUpdate = false)
        {
            string json;
            if (firstUpdate || forceFirstUpdate)
            {
                json = JsonConvert.SerializeObject(new[] { DOMBuilder.DOM }, new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
                //json = JsonSerializer.Serialize<object[]>(new[] { DOMBuilder.DOM }, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreReadOnlyProperties = false });
                //json = new[] { DOMBuilder.DOM }.Serialize();
                DOMBuilder.GetPatches(); //clear pathches
            }
            else
            {
                var patches = DOMBuilder.GetPatches();
                //json = JsonSerializer.Serialize<object[]>(patches.Select(p=>(object)p).ToArray(), new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreReadOnlyProperties = false });
                json = JsonConvert.SerializeObject(patches, new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                });
                //json = patches.Serialize();
            }
            //Task.Run(async () =>
            //{
                //if (firstUpdate)
                //{
                //    await Task.Delay(30000);
                //}
                var script = $"window.webView.update({json}, {forceFirstUpdate.ToString().ToLower()})";
                await Device.InvokeOnMainThreadAsync(() => WebView.P.EvaluateJavaScriptAsync(script));
                firstUpdate = false;
            //});
        }

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
            if (firstUpdate == false)
            {
                return UpdateDOM();
            }
            //Update();
            //var json = JsonSerializer.Serialize<object[]>(patches.Select(p=>(object)p).ToArray(), new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreReadOnlyProperties = false });
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
