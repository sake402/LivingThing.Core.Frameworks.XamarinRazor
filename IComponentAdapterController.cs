using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    public interface IComponentAdapterController
    {
        IServiceProvider ServiceProvider { get; }
        IComponentAdapterController Parent { get; }
        object RootElement { get; set; }
        Task<VisualElement> VisualElement { get; }

        void Add(object element, int index, bool @throw = true);
        void Remove(int index);
        void Replace(object oldElement, object newElement, bool @throw = true);
    }
}