using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace LivingThing.Core.Frameworks.XamarinRazor
{
    class DelegateConverter<T> : IValueConverter
    {
        Func<T, object> Delegate;

        public DelegateConverter(Func<T, object> @delegate)
        {
            Delegate = @delegate;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Delegate((T)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BaseComponent:ComponentBase, IDisposable
    {
        //public static Binding Binding<TViewModel, TTarget>(TViewModel viewModel, Expression<Func<TViewModel, TTarget>> exp)
        //{
        //    var path = exp.ToString();
        //    var lambdaIndex = path.IndexOf("=>");
        //    var lamdaPath = path.Substring(lambdaIndex+2).Trim();
        //    var firstDot = lamdaPath.IndexOf(".");
        //    if (firstDot >= 0)
        //    {
        //        lamdaPath = lamdaPath.Substring(firstDot + 1);
        //    }
        //    else
        //    {
        //        lamdaPath = ".";
        //    }
        //    return new Binding(lamdaPath);
        //}

        public static Binding Binding<TViewModel, TTarget>(TViewModel source, Expression<Func<TViewModel, TTarget>> exp, Func<TTarget, object> converter = null, string format = null, BindingMode mode = BindingMode.Default)
        {
            var path = exp.ToString();
            var lambdaIndex = path.IndexOf("=>");
            var lamdaPath = path.Substring(lambdaIndex + 2).Trim();
            var firstDot = lamdaPath.IndexOf(".");
            if (firstDot >= 0)
            {
                lamdaPath = lamdaPath.Substring(firstDot + 1);
            }
            else
            {
                lamdaPath = ".";
            }
            return new Binding(lamdaPath, mode, converter != null ? new DelegateConverter<TTarget>(converter) : null, null, format, source);
        }

        public static Thickness Thickness(double value)
        {
            return new Thickness(value);
        }

        public static Thickness Thickness(double horizontal, double vertical)
        {
            return new Thickness(horizontal, vertical);
        }

        public static Thickness Thickness(double left, double top, double right, double bottom)
        {
            return new Thickness(left, top, right, bottom);
        }

        public void Dispose()
        {

        }
    }
}
