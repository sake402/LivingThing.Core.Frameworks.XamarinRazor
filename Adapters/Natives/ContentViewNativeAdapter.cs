//using System;
//using XF = Xamarin.Forms;

//namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
//{
//    internal class ContentViewNativeAdapter : INativeAdapter<XF.ContentView>
//    {
//        public bool Add(XF.ContentView contentView, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view)
//            {
//                var stackLayout = contentView.Content as XF.StackLayout;
//                if (stackLayout == null)
//                {
//                    stackLayout = new XF.StackLayout();
//                    contentView.Content = stackLayout;
//                }
//                stackLayout.Children.Insert(index, view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{contentView.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Remove(XF.ContentView contentView, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view)
//            {
//                var stackLayout = contentView.Content as XF.StackLayout;
//                stackLayout.Children.Remove(view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{contentView.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Replace(XF.ContentView contentView, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view && newChild is XF.View newView)
//            {
//                var stackLayout = contentView.Content as XF.StackLayout;
//                int index = stackLayout.Children.IndexOf(view);
//                stackLayout.Children.RemoveAt(index);
//                stackLayout.Children.Insert(index, newView);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{contentView.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }
//    }
//}
