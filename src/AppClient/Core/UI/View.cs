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
            "Model", null, false, BindingMode.OneWay);

        private static void HandleModelChanged(IAvaloniaObject element, object viewValue)
        {
            if (element is IContentControl interactElem)
            {
                if (viewValue != null)
                {
                    var control = ServiceLocator.Get<ViewLocator>().Build(viewValue);
                    control.DataContext = viewValue;                    
                    interactElem.Content = control;
                }
                else
                {
                    interactElem.Content = null;
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
