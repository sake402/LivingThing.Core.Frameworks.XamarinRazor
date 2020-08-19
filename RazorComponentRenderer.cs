using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
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


        IComponent RootComponent;
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
            RootComponent = component;
            //}).ConfigureAwait(false);
            if (adapter.RootElement is BridgeComponentBase @base)
                return @base.Native as TRootElement;
            return adapter.RootElement as TRootElement;
        }

        MethodInfo invokeAsync;
        MethodInfo stateHasChanged;
        Action rerender;

        public void ReRender()
        {
            invokeAsync ??= typeof(ComponentBase).GetMethod("InvokeAsync", bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance, types: new Type[] { typeof(Action) }, binder: null, modifiers: null);
            stateHasChanged ??= typeof(ComponentBase).GetMethod("StateHasChanged", BindingFlags.NonPublic | BindingFlags.Instance);
            rerender ??= () => stateHasChanged.Invoke(RootComponent, new object[] { });
            invokeAsync.Invoke(RootComponent, new object[] { rerender });
        }

        void PrintException(Exception exception)
        {
            Debug.WriteLine($"{nameof(RazorComponentRenderer)} exception type '{exception?.GetType().Name}': '{exception?.Message}' => \r\n{exception.StackTrace}");
            if (exception.InnerException != null)
            {
                PrintException(exception.InnerException);
            }
        }

        protected override void HandleException(Exception exception)
        {
            PrintException(exception);
            XF.Device.InvokeOnMainThreadAsync(() =>
            {
                XF.Application.Current.MainPage = GetErrorPageForException(exception);
            });
        }

        private static XF.View  GetInnerExceptioView(Exception exception)
        {
            if (exception == null)
                return new StackLayout();
            return new StackLayout()
            {
                Children =
                {
                    new XF.Label
                    {
                        FontSize = XF.Device.GetNamedSize(XF.NamedSize.Medium, typeof(XF.Label)),
                        Text = exception?.Message,
                    },
                    new XF.Label
                    {
                        FontSize = XF.Device.GetNamedSize(XF.NamedSize.Small, typeof(XF.Label)),
                        Text = exception?.StackTrace,
                    },
                    GetInnerExceptioView(exception?.InnerException)
                }
            };
        }
        private static XF.ContentPage GetErrorPageForException(Exception exception)
        {
            var errorPage = new XF.ContentPage()
            {
                Title = $"Unhandled exception({exception.GetType().Name})",
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
                            Content = new StackLayout()
                            {
                                Children =
                                {
                                    new XF.Label
                                    {
                                        FontSize = XF.Device.GetNamedSize(XF.NamedSize.Small, typeof(XF.Label)),
                                        Text = exception?.StackTrace,
                                    },
                                    GetInnerExceptioView(exception?.InnerException)
                                }
                            }   
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
