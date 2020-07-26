//using LivingThing.Core.Frameworks.XamarinRazor.Forms;
//using System;
//using Xamarin.Forms;
//using XF = Xamarin.Forms;

//namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
//{
//    internal class ContentPageNativeAdapter : INativeAdapter<XF.ContentPage>
//    {
//        public bool Add(XF.ContentPage page, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is View view)
//            {
//                var stackLayout = page.Content as XF.StackLayout;
//                if (stackLayout == null)
//                {
//                    stackLayout = new XF.StackLayout();
//                    page.Content = stackLayout;
//                }
//                stackLayout.Children.Insert(index, view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{page.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Remove(XF.ContentPage page, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is View view)
//            {
//                var stackLayout = page.Content as XF.StackLayout;
//                stackLayout.Children.Remove(view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{page.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Replace(XF.ContentPage page, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is View view && newChild is View newView)
//            {
//                var stackLayout = page.Content as XF.StackLayout;
//                int index = stackLayout.Children.IndexOf(view);
//                stackLayout.Children.RemoveAt(index);
//                stackLayout.Children.Insert(index, newView);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{page.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }
//    }
//}
