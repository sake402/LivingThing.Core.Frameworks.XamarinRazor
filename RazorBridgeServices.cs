using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components;
using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Components.WebView;
using LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.IO;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public static class Initializer
    {
        public static void UseXamarinRazor(this IServiceCollection services)
        {
            services.AddTransient<IJSRuntime>((s) => WebViewJsRuntime.Current);
            services.AddSingleton<WebViewNavigationManager>().AddSingleton<NavigationManager>((x) => x.GetRequiredService<WebViewNavigationManager>());
            services.AddTransient(typeof(Razor<>));
            services.AddSingleton<ComponentToParameterAdapter>().AddSingleton<IComponentAdapter<ComponentToParameterBridge>>(x => x.GetService<ComponentToParameterAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<ComponentToParameterAdapter>());
            services.AddSingleton<ComponentToElementAdapter>().AddSingleton<IComponentAdapter<ComponentToXamarinBridge>>(x => x.GetService<ComponentToElementAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<ComponentToElementAdapter>());
            services.AddSingleton<ViewCellComponentAdapter>().AddSingleton<IComponentAdapter<XRF.ViewCell>>(x => x.GetRequiredService<ViewCellComponentAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<ViewCellComponentAdapter>()); ;
            services.AddSingleton<RazorComponentAdapter>().AddSingleton<IComponentAdapter<ComponentBase>>(x => x.GetRequiredService<RazorComponentAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<RazorComponentAdapter>()); ;
            services.AddSingleton<ComponentToDataTemplateAdapter>().AddSingleton<IComponentAdapter<XRF.DataTemplate>>(x => x.GetRequiredService<ComponentToDataTemplateAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<ComponentToDataTemplateAdapter>());
            services.AddSingleton<StyleSheetAdapter>().AddSingleton<IComponentAdapter<StyleSheet>>(x => x.GetRequiredService<StyleSheetAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<StyleSheetAdapter>()); ;
            services.AddSingleton<ComponentToWebViewAdapter>().AddSingleton<IComponentAdapter<XRF.WebView>>(x => x.GetRequiredService<ComponentToWebViewAdapter>()).AddSingleton<IComponentAdapter>(x => x.GetService<ComponentToWebViewAdapter>()); ;
            //services.AddSingleton(typeof(IComponentAdapter<>), typeof(RazorComponentAdapter<>));
            //services.AddSingleton(typeof(IComponentAdapter<>), typeof(ComponentToElementAdapter<>));
            //services.AddSingleton<ContentPageNativeAdapter>().AddSingleton<INativeAdapter<XF.ContentPage>>(x => x.GetService<ContentPageNativeAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<ContentPageNativeAdapter>());
            //services.AddSingleton<ContentViewNativeAdapter>().AddSingleton<INativeAdapter<XF.ContentView>>(x => x.GetService<ContentViewNativeAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<ContentViewNativeAdapter>());

            //Without this two services below, it uses the DefaultNativeElementAdapter which does the same thing using reflection
            //services.AddSingleton<LayoutViewAdapter>().AddSingleton<INativeAdapter<XF.Layout<XF.View>>>(x => x.GetService<LayoutViewAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<LayoutViewAdapter>());
            //services.AddSingleton<MultiPageAdapter>().AddSingleton<INativeAdapter<XF.MultiPage<XF.Page>>>(x => x.GetService<MultiPageAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<MultiPageAdapter>());

            services.AddSingleton<ShellContentNativeElementAdapter>().AddSingleton<INativeAdapter<XF.ShellContent>>(x => x.GetService<ShellContentNativeElementAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<ShellContentNativeElementAdapter>());
            services.AddSingleton<ShellNativeElementAdapter>().AddSingleton<INativeAdapter<XF.Shell>>(x => x.GetService<ShellNativeElementAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<ShellNativeElementAdapter>());

            services.AddSingleton<DataTemplateNativeAdapter>().AddSingleton<INativeAdapter<XRF.DataTemplate>>(x => x.GetService<DataTemplateNativeAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<DataTemplateNativeAdapter>());
            services.AddSingleton<DefaultNativeElementAdapter>().AddSingleton<INativeAdapter<object>>(x => x.GetService<DefaultNativeElementAdapter>()).AddSingleton<INativeAdapter>(x => x.GetService<DefaultNativeElementAdapter>());

            //service provider doesnt support different open generics with different constraint parameter as it only tries to use the last registered one even if the constraint isnt valid
            //services.AddSingleton(typeof(IElementAdapter<>), typeof(LayoutViewAdapter<>));
            //services.AddSingleton(typeof(IElementAdapter<>), typeof(MultiPageAdapter<>));
        }

        public static IServiceProvider Initialize(Action<IServiceCollection> registerServices)
        {
            var builder = new HostBuilder();

            builder.UseContentRoot(Directory.GetCurrentDirectory());

            var host = builder.ConfigureServices(services =>
            {
                services.UseXamarinRazor();
                registerServices(services);
            })
            .ConfigureLogging((HostBuilderContext hostingContext, ILoggingBuilder logging) =>
            {
                logging.AddConsole(configure => configure.DisableColors = true);
                logging.AddDebug();
                logging.AddEventSourceLogger();
            })
            .UseDefaultServiceProvider((context, options) =>
            {
                var isDevelopment = context.HostingEnvironment.IsDevelopment();
                options.ValidateScopes = isDevelopment;
                options.ValidateOnBuild = isDevelopment;
            }).Build();
            return host.Services;
        }

    }
}
