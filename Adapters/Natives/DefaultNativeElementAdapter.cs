using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    //this class exist only so we can differentiate between a StackLayout we are using to wrap more than one contents place inside a view that allows only one
    public class StackContainer : XF.StackLayout
    {

    }     
 
    public class DefaultNativeElementAdapter : INativeAdapter<XF.Element>
    {
        static bool IsAssignableFrom(Type lhs, object rhs)
        {
            Type rhsType;
            if (rhs is BridgeComponentBase bridge)
            {
                rhsType = bridge.Native.GetType();
            }
            else
            {
                rhsType = rhs.GetType();
            }
            return lhs.IsAssignableFrom(rhsType);
        }

        (PropertyInfo Property, object Target) GetTarget(XF.Element view, object child)
        {
            PropertyInfo property = null;
            object target = null;
            if (child is BridgeComponentBase component && component.Property != null)
            {
                if (component.Property == "BindableLayoutItemTemplate")
                {
                    XF.BindableLayout.SetItemTemplate(view, (child as XRF.DataTemplate).P);
                }
                else
                {
                    property = view.GetType().GetProperty(component.Property);
                    if (property == null)
                    {
                        throw new InvalidOperationException($"No such property as {component.Property} can be found on {view.GetType().Name}");
                    }
                    if (!IsAssignableFrom(property.PropertyType, child))
                    {
                        throw new InvalidOperationException($"Cannot assign {child.GetType()} to {component.Property} on {view.GetType()}");
                    }
                }
                target = component.Native;
            }
            else
            {
                if (child is BridgeComponentBase _component)
                {
                    target = _component.Native;
                }
                else
                {
                    target = child;
                }
                //var properties = view.GetType().GetProperties().Where(p => p.PropertyType == child.GetType()).ToArray();
                var properties = view.GetType().GetProperties().Where(property =>
                {
                   if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) && IsAssignableFrom(property.PropertyType.GetGenericArguments()[0], child))
                    {
                        return true;
                    }
                    return false;
                }).ToArray();
                if (properties.Length == 0)
                {
                    properties = view.GetType().GetProperties().Where(property =>
                    {
                        if (!property.CanWrite)
                            return false;
                        if (property.PropertyType!= typeof(object) && IsAssignableFrom(property.PropertyType, child))
                            return true;
                        return false;
                    }).ToArray();
                }
                if (properties.Length > 1)
                {
                    var declaringTypes = properties.Select(p => p.DeclaringType).Distinct().ToArray();
                    //get the highest hierachy in the types
                    var highestType = declaringTypes.Aggregate((t1, t2) =>
                    {
                        if (t1.IsAssignableFrom(t2))
                            return t2;
                        return t1;
                    });
                    properties = properties.Where(p => p.DeclaringType == highestType).ToArray();
                }
                if (properties.Length > 1)
                {
                    throw new InvalidOperationException($"The type {view.GetType().Name} has more than one property with type {child.GetType().Name}. Specify the target property by providing the Property attribute");
                }
                else if (properties.Length == 0)
                {
                    throw new InvalidOperationException($"The type {view.GetType().Name} has no property with type {child.GetType().Name}.");
                }
                property = properties[0];
            }
            return (property, target);
        }

        public bool Add(XF.Element view, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{view.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            var setter = GetTarget(view, child);
            if (setter.Property == null) //static methods already handled
                return true;
            if (setter.Property.PropertyType.IsGenericType && setter.Property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var collection = setter.Property.GetValue(view);
                var addMethod = collection.GetType().GetMethod("Add");
                addMethod.Invoke(collection, new object[] { setter.Target });
            }
            else
            {
                var currentValue = setter.Property.GetValue(view);
                if (currentValue == null)
                {
                    setter.Property.SetValue(view, setter.Target);
                }
                //we have a parent view that can only take one child view, and the user is adding more than one child to it.
                //convert the child to stack layout and add all childs to the stack
                else
                {
                    if (currentValue is StackContainer container)
                    {
                        container.Children.Add(setter.Target as XF.View);
                    }
                    else
                    {
                        XF.View currentView = currentValue as XF.View;
                        StackContainer stackLayout = new StackContainer();
                        stackLayout.Children.Add(currentView);
                        stackLayout.Children.Add(setter.Target as XF.View);
                        setter.Property.SetValue(view, stackLayout);
                    }
                }
            }
            return true;
        }

        public bool Remove(XF.Element view, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{view.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            var setter = GetTarget(view, child);
            if (setter.Property.PropertyType.IsGenericType && setter.Property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var collection = setter.Property.GetValue(view);
                var removeMethod = collection.GetType().GetMethod("Remove");
                removeMethod.Invoke(collection, new object[] { setter.Target });
            }
            else
            {
                var currentValue = setter.Property.GetValue(view);
                if (currentValue is StackContainer container)
                {
                    container.Children.Remove(setter.Target as XF.View);
                }
                else
                {
                    setter.Property.SetValue(view, null);
                }
            }
            return true;
        }

        public bool Replace(XF.Element view, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{view.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            var setter = GetTarget(view, child);
            if (setter.Property == null) //static setter already handled by GetTarget
                return true;
            if (child is ComponentToXamarinBridge childXamarinBridge)
            {
                child = childXamarinBridge.Element;
            }
            else if (child is ComponentToParameterBridge childParameterBridge)
            {
                child = childParameterBridge.Native;
            }
            if (newChild is ComponentToXamarinBridge newChildXamarinBridge)
            {
                newChild = newChildXamarinBridge.Element;
            }
            else if (newChild is ComponentToParameterBridge newCildParameterBridge)
            {
                newChild = newCildParameterBridge.Native;
            }
            if (setter.Property.PropertyType.IsGenericType && setter.Property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var collection = setter.Property.GetValue(view) as IEnumerable<object>;
                int index = Array.IndexOf(collection.ToArray(), child);
                var indexMethod = collection.GetType().GetMethod("set_Item");
                indexMethod.Invoke(collection, new object[] { index, newChild });
            }
            else
            {
                var currentValue = setter.Property.GetValue(view);
                if (currentValue is StackContainer container)
                {
                    var _view = setter.Target as XF.View;
                    int index = container.Children.IndexOf(_view);
                    container.Children.Remove(_view);
                    container.Children.Insert(index, newChild as XF.View);
                }
                else
                {
                    setter.Property.SetValue(view, newChild);
                }
            }
            return true;
        }
    }
}
