using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF = Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    internal class RazorComponentRenderer : Renderer
    {
        internal Dictionary<int, ComponentAdapterController> Adapters = new Dictionary<int, ComponentAdapterController>();
        public RazorComponentRenderer(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetRequiredService<ILoggerFactory>())
        {
            ServiceProvider = serviceProvider;
        }

        internal IServiceProvider ServiceProvider { get; }
        internal ILoggerFactory LoggerFactory { get; }

        public override Dispatcher Dispatcher => new XamarinDeviceDispatcher();

        public Task<TRootElement> AddComponent<TComponent, TRootElement>(Element parentElement, Action<TComponent> parameterSetter) where TRootElement : class
        {
            return AddComponent<TRootElement>(typeof(TComponent), parentElement, (o)=> parameterSetter?.Invoke((TComponent)o));
        }

        public async Task<TRootElement> AddComponent<TRootElement>(Type componentType, Element parentElement, Action<object> parameterSetter) where TRootElement:class
        {
            ComponentAdapterController adapter = null;
            //await Dispatcher.InvokeAsync(async () =>
            //{
                var component = InstantiateComponent(componentType);
                var componentId = AssignRootComponentId(component);
                parameterSetter?.Invoke(component);

                adapter = new ComponentAdapterController(this, component, parentElement);
                Adapters[componentId] = adapter;

                await RenderRootComponentAsync(componentId).ConfigureAwait(false);
            //}).ConfigureAwait(false);
            if (adapter.RootElement is BridgeComponentBase @base)
                return @base.Native as TRootElement;
            return adapter.RootElement as TRootElement;
        }

        protected override void HandleException(Exception exception)
        {
            Debug.WriteLine($"{nameof(HandleException)} called with '{exception?.GetType().Name}': '{exception?.Message}'");

            XF.Device.InvokeOnMainThreadAsync(() =>
            {
                XF.Application.Current.MainPage = GetErrorPageForException(exception);
            });
        }

        private static XF.ContentPage GetErrorPageForException(Exception exception)
        {
            var errorPage = new XF.ContentPage()
            {
                Title = "Unhandled exception",
                BackgroundColor=XF.Color.White,
                Content = new XF.StackLayout
                {
                    Padding = 10,
                    Children =
                    {
                        new XF.Label
                        {
                            FontAttributes = XF.FontAttributes.Bold,
                            FontSize = XF.Device.GetNamedSize(XF.NamedSize.Large, typeof(XF.Label)),
                            Text = "Unhandled exception",
                        },
                        new XF.Label
                        {
                            Text = exception?.Message,
                        },
                        new XF.ScrollView
                        {
                            Content =
                                new XF.Label
                                {
                                    FontSize = XF.Device.GetNamedSize(XF.NamedSize.Small, typeof(XF.Label)),
                                    Text = exception?.StackTrace,
                                },

                        },
                    },
                },
            };

            return errorPage;
        }

        protected override Task UpdateDisplayAsync(in RenderBatch renderBatch)
        {
            foreach (var updatedComponent in renderBatch.UpdatedComponents.Array.Take(renderBatch.UpdatedComponents.Count))
            {
                var adapter = Adapters[updatedComponent.ComponentId];
                adapter.Apply(updatedComponent, renderBatch);
            }
            foreach (var updatedComponent in renderBatch.DisposedComponentIDs.Array.Take(renderBatch.DisposedComponentIDs.Count))
            {
                Adapters[updatedComponent].Dispose();
                Adapters.Remove(updatedComponent);
            }
            return Task.CompletedTask;
        }
    }
}
