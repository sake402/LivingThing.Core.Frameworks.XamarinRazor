
using Microsoft.AspNetCore.Components;

namespace LivingThing.Core.Frameworks.XamarinRazor.Forms
{
    public partial class CookieContainer : ComponentToParameterBridge<System.Net.CookieContainer, CookieContainer>
    {
        public CookieContainer()
        {
        }
        public CookieContainer(System.Net.CookieContainer _parameter):base(_parameter)
        {
        }
		[Parameter] public System.Int32 Capacity { set => P.Capacity = value; get => P.Capacity; }
		[Parameter] public System.Int32 MaxCookieSize { set => P.MaxCookieSize = value; get => P.MaxCookieSize; }
		[Parameter] public System.Int32 PerDomainCapacity { set => P.PerDomainCapacity = value; get => P.PerDomainCapacity; }
    }
}
