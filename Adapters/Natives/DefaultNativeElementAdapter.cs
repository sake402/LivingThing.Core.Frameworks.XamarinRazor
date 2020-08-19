using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XF = Xamarin.Forms;
using XRF = LivingThing.Core.Frameworks.XamarinRazor.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor.Adapters.Natives
{
    //this class exist only so we can differentiate between a StackLayout we are using to wrap more than one contents place inside a view that allows only one
    public class StackContainer : XF.StackLayout
    {

    }     
 
    public class DefaultNativeElementAdapter : INativeAdapter<object>
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

        class CollectionMethodDescriptor
        {
            public MethodInfo Add { get; set; }
            public MethodInfo Remove { get; set; }
        }

        CollectionMethodDescriptor GetCollectionMethod(Type listType, Type itemType) //^IList<View> AbsoluteLayout => true
        {
            if (!typeof(IEnumerable).IsAssignableFrom(listType))
            {
                return null;
            }
            List<MethodInfo> methods = new List<MethodInfo>(listType.GetMethods(BindingFlags.Public | BindingFlags.Instance));
            foreach (Type interf in listType.GetInterfaces())
            {
                foreach (MethodInfo method in interf.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    if (!methods.Contains(method))
                        methods.Add(method);
            }
            //var methods = listType.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.FlattenHierarchy|BindingFlags.);
            //return methods != null;
            var add = methods.FirstOrDefault(m =>
            {
                if (m.Name != "Add")
                    return false;
                var @params = m.GetParameters();
                if (@params.Length != 1)
                    return false;
                var paramType = @params[0].ParameterType;
                if (paramType == typeof(object))
                    return false;
                return paramType.IsAssignableFrom(itemType);
            });
            var remove = methods.FirstOrDefault(m =>
            {
                if (m.Name != "Remove")
                    return false;
                var @params = m.GetParameters();
                if (@params.Length != 1)
                    return false;
                var paramType = @params[0].ParameterType;
                if (paramType == typeof(object))
                    return false;
                return paramType.IsAssignableFrom(itemType);
            });
            return (add != null || remove != null) ? new CollectionMethodDescriptor() { Add = add, Remove = remove } : null;
            //if (method == null)
            //    return false;
            //var @params = method.GetParameters();
            //if (@params.Length != 1)
            //    return false;
            //var paramType = @params[0].ParameterType;
            //return paramType.IsAssignableFrom(itemType);
            //return typeof(IList<>).MakeGenericType(itemType).IsAssignableFrom(listType);
        }

        class TargetMethodDescriptor
        {
            public PropertyInfo Property { get; set; }
            public CollectionMethodDescriptor Method { get; set; }
            public object Target { get; set; }
        }

        TargetMethodDescriptor GetTarget(object parent, object child)
        {
            PropertyInfo property = null;
            CollectionMethodDescriptor method = null;
            object target = null;
            var childType = child.GetType();
            var parentType = parent.GetType();
            if (child is BridgeComponentBase component && component.Property != null)
            {
                target = component.Native;
                childType = target.GetType();
                if (component.Property == "BindableLayoutItemTemplate")
                {
                    XF.BindableLayout.SetItemTemplate((BindableObject)parent, (child as XRF.DataTemplate).P);
                }
                else
                {
                    property = parent.GetType().GetProperty(component.Property);
                    if (property == null)
                    {
                        throw new InvalidOperationException($"No such property as {component.Property} can be found on {parent.GetType().Name}");
                    }
                    if ((method = GetCollectionMethod(property.PropertyType, childType)) != null)
                    {

                    }
                    else if (!IsAssignableFrom(property.PropertyType, target))
                    {
                        throw new InvalidOperationException($"Cannot assign {child.GetType()} to {component.Property} on {parent.GetType()}");
                    }
                }
            }
            else
            {
                if (child is BridgeComponentBase _component)
                {
                    target = _component.Native;
                    childType = target.GetType();
                }
                else
                {
                    target = child;
                }
                //var properties = view.GetType().GetProperties().Where(p => p.PropertyType == child.GetType()).ToArray();
                var viewProperties = parent.GetType().GetProperties();
                (PropertyInfo property, CollectionMethodDescriptor method)[] propertyMethods = viewProperties.Select(property =>
                {
                    if (property.Name == "Item")
                        return (null, null);

                    CollectionMethodDescriptor method = null;
                    if ((method = GetCollectionMethod(property.PropertyType, child.GetType())) != null)
                        return (property, method);

                    if (!property.CanWrite)
                        return (null, null);
                    if (property.PropertyType != typeof(object) && IsAssignableFrom(property.PropertyType, child))
                        return (property, null);
                    return (null, null);
                    //if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) && IsAssignableFrom(property.PropertyType.GetGenericArguments()[0], child))
                    // {
                    //     return true;
                    // }
                    //return false;
                }).Where(pm => pm.property != null).ToArray();
                //if (properties.Length == 0)
                //{
                //    properties = viewProperties.Where(property =>
                //    {
                //        if (!property.CanWrite)
                //            return false;
                //        if (property.PropertyType!= typeof(object) && IsAssignableFrom(property.PropertyType, child))
                //            return true;
                //        return false;
                //    }).ToArray();
                //}
                //if not property match, find an Add method
                if (propertyMethods.Length == 0)
                {
                    var _method = GetCollectionMethod(parentType, childType);
                    if (_method != null)
                    {
                        propertyMethods = new (PropertyInfo property, CollectionMethodDescriptor method)[] { (null, _method) };
                    }
                }
                //use the highest property in the inheritance hierachy
                if (propertyMethods.Length > 1)
                {
                    var declaringTypes = propertyMethods.Select(p => p.property.DeclaringType).Distinct().ToArray();
                    //get the highest hierachy in the types
                    var highestType = declaringTypes.Aggregate((t1, t2) =>
                    {
                        if (t1.IsAssignableFrom(t2))
                            return t2;
                        return t1;
                    });
                    propertyMethods = propertyMethods.Where(p => p.property.DeclaringType == highestType).ToArray();
                }
                //prioritize Collection property
                if (propertyMethods.Length > 1)
                {
                    var listTypes = propertyMethods.Where(p => p.method != null /*typeof(IEnumerable).IsAssignableFrom(p.property.PropertyType)*/).ToArray();
                    if (listTypes.Length == 1)
                        propertyMethods = listTypes;
                }
                //use the property that exactly match child
                if (propertyMethods.Length > 1)
                {
                    propertyMethods = propertyMethods.Where(p =>
                    {
                        if (p.method?.Add != null)
                        {
                            return p.method.Add.GetParameters()[0].ParameterType == childType;
                        }
                        else
                        {
                            return p.property.PropertyType == childType;
                        }
                    }).ToArray();
                }
                //prioritize non-obsolete property
                if (propertyMethods.Length > 1)
                {
                    propertyMethods = propertyMethods.Where(pm => pm.property.GetCustomAttribute<ObsoleteAttribute>() == null).ToArray();
                }
                if (propertyMethods.Length > 1)
                {
                    throw new InvalidOperationException($"The type {parent.GetType().Name} has more than one property that can accept type {child.GetType().Name}. Specify the target property by providing the Property attribute");
                }
                else if (propertyMethods.Length == 0)
                {
                    throw new InvalidOperationException($"The type {parent.GetType().Name} has no property with type {child.GetType().Name}.");
                }
                property = propertyMethods[0].property;
                method = propertyMethods[0].method;
            }
            return new TargetMethodDescriptor() { Property = property, Method = method, Target = target };
        }

        public bool Add(object parent, int index, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{parent.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            TargetMethodDescriptor setter;
            try
            {
                setter = GetTarget(parent, child);
            }
            catch(Exception e)
            {
            }
            setter = GetTarget(parent, child);
            if (setter.Property == null && setter.Method?.Add == null) //static methods already handled
                return true;
            if (setter.Method?.Add != null)
            {
                var addMethod = setter.Method.Add;
                if (setter.Property != null)
                {
                    var collection = setter.Property.GetValue(parent);
                    addMethod.Invoke(collection, new object[] { setter.Target });
                }
                else
                {
                    addMethod.Invoke(parent, new object[] { setter.Target });
                }
            }
            else
            {
                var currentValue = setter.Property.GetValue(parent);
                if (currentValue == null || 
                    (typeof(IEnumerable).IsAssignableFrom(setter.Property.PropertyType) && setter.Property.PropertyType.IsAssignableFrom(child.GetType())))//fix for GradientCollection in PancakeView
                {
                    setter.Property.SetValue(parent, setter.Target);
                }
                //we have a parent view that can only take one child view, and the user is adding more than one child to it.
                //convert the child to stack layout and add all childs to the stack
                else
                {
                    var targetChild = setter.Target as XF.View;
                    if (targetChild == null)
                    {
                        throw new InvalidOperationException($"Only views can be stacked into element that that would rather take one child element. Type {setter.Target.GetType()} not allowed");
                    }
                    if (currentValue is StackContainer container)
                    {
                        container.Children.Insert(index, targetChild);
                    }
                    else
                    {
                        XF.View currentView = currentValue as XF.View;
                        if (currentView == null)
                        {
                            throw new InvalidOperationException($"Only views can be stacked into element that that would rather take one child element. Type {setter.Target.GetType()} not allowed");
                        }
                        StackContainer stackLayout = new StackContainer();
                        stackLayout.Children.Add(currentView);
                        stackLayout.Children.Add(targetChild);
                        setter.Property.SetValue(parent, stackLayout);
                    }
                }
            }
            return true;
        }

        public bool Remove(object parent, object child, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{parent.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            var setter = GetTarget(parent, child);
            if (setter.Property == null && setter.Method?.Remove == null) //static methods already handled
                return true;
            if (setter.Method?.Remove != null)
            {
                var removeMethod = setter.Method.Remove;
                if (setter.Property != null)
                {
                    var collection = setter.Property.GetValue(parent);
                    removeMethod.Invoke(collection, new object[] { setter.Target });
                }
                else
                {
                    removeMethod.Invoke(parent, new object[] { setter.Target });
                }
            }
            else
            {
                var currentValue = setter.Property.GetValue(parent);
                if (currentValue is StackContainer container)
                {
                    container.Children.Remove(setter.Target as XF.View);
                }
                else
                {
                    setter.Property.SetValue(parent, null);
                }
            }
            return true;
        }

        public bool Replace(object parent, object child, object newChild, IComponentAdapterController rootAdapter, bool @throw = true)
        {
            if (child == null)
            {
                if (@throw)
                    throw new InvalidOperationException($"{parent.GetType()} supports only non-null ChildContent");
                else
                    return false;
            }
            var setter = GetTarget(parent, child);
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
                var collection = setter.Property.GetValue(parent) as IEnumerable<object>;
                int index = Array.IndexOf(collection.ToArray(), child);
                var indexMethod = collection.GetType().GetMethod("set_Item");
                indexMethod.Invoke(collection, new object[] { index, newChild });
            }
            else
            {
                var currentValue = setter.Property.GetValue(parent);
                if (currentValue is StackContainer container)
                {
                    var _view = setter.Target as XF.View;
                    int index = container.Children.IndexOf(_view);
                    container.Children.Remove(_view);
                    container.Children.Insert(index, newChild as XF.View);
                }
                else
                {
                    setter.Property.SetValue(parent, newChild);
                }
            }
            return true;
        }
    }
}
