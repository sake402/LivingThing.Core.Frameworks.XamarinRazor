//using System;
//using XF = Xamarin.Forms;

//namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
//{
//    internal class LayoutViewNativeAdapter<TLayout> : INativeAdapter<TLayout> where TLayout : XF.Layout<XF.View>
//    {
//        public bool Add(TLayout layout, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view)
//            {
//                layout.Children.Insert(index, view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{layout.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Remove(TLayout layout, object child, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view)
//            {
//                layout.Children.Remove(view);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{layout.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }

//        public bool Replace(TLayout layout, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
//        {
//            if (child is XF.View view && newChild is XF.View newView)
//            {
//                int index = layout.Children.IndexOf(view);
//                layout.Children.RemoveAt(index);
//                layout.Children.Insert(index, newView);
//                return true;
//            }
//            if (@throw)
//                throw new InvalidOperationException($"{layout.GetType()} supports only ChildContent of type {typeof(XF.View)}");
//            return false;
//        }
//    }

//    internal class LayoutViewAdapter : LayoutViewNativeAdapter<XF.Layout<XF.View>>
//    { 
//    }
//}
