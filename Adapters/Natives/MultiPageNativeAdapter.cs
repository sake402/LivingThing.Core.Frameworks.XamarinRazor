//using System;
//using XF = Xamarin.Forms;

//namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
//{
//    internal class MultiPageNativeAdapter<TPage> : INativeAdapter<TPage> where TPage : XF.MultiPage<XF.Page>
//    {
//        public bool Add(TPage multiPage, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.Page page)
//            {
//                multiPage.Children.Insert(index, page);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{multiPage.GetType()} supports only ChildContent of type {typeof(XF.Page)}");
//            return false;
//        }

//        public bool Remove(TPage multiPage, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.Page page)
//            {
//                multiPage.Children.Remove(page);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{multiPage.GetType()} supports only ChildContent of type {typeof(XF.Page)}");
//            return false;
//        }

//        public bool Replace(TPage multiPage, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.Page page && newChild is XF.Page newPage)
//            {
//                int index = multiPage.Children.IndexOf(page);
//                multiPage.Children.RemoveAt(index);
//                multiPage.Children.Insert(index, newPage);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{multiPage.GetType()} supports only ChildContent of type {typeof(XF.Page)}");
//            return false;
//        }
//    }

//    internal class MultiPageAdapter:MultiPageNativeAdapter<XF.MultiPage<XF.Page>> 
//    {
//    }
//}
