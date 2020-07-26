using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    internal class XamarinDeviceDispatcher : Dispatcher
    {
        public override bool CheckAccess()
        {
            return !Device.IsInvokeRequired;
        }

        public override Task InvokeAsync(Action workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task InvokeAsync(Func<Task> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task<TResult> InvokeAsync<TResult>(Func<TResult> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task<TResult> InvokeAsync<TResult>(Func<Task<TResult>> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }
    }
}
