using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

using FlexiObject.Core.Config;

using PropertyChanged;

using System;

namespace FlexiObject.AppClient.Core.UI
{
    [DoNotNotify]
    public class View : AvaloniaObject
    {
        static View()
        {
            ModelProperty.Changed.Subscribe(x => HandleModelChanged(x.Sender, x.NewValue.GetValueOrDefault<object>()));
        }

        public static readonly AttachedProperty<object> ModelProperty = AvaloniaProperty.RegisterAttached<View, IContentControl, object>(
            "Model", null, false, BindingMode.TwoWay);

        private static void HandleModelChanged(IAvaloniaObject element, object viewValue)
        {
            if (element is IContentControl interactElem)
            {
                if (viewValue != null)
                {
                    interactElem.DataContext = viewValue;
                    interactElem.Content = ServiceLocator.Get<ViewLocator>().Build(viewValue);
                }
                else
                {
                    //interactElem.DataContext = null;
                    //interactElem.Content = null;
                }
            }
        }

        public static void SetModel(AvaloniaObject element, object value)
        {
            element.SetValue(ModelProperty, value);
        }

        public static object GetModel(IAvaloniaObject element)
        {
            return element.GetValue(ModelProperty);
        }
    }
}
