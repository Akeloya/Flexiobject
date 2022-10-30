using Avalonia.Controls;
using Avalonia.Controls.Templates;

using FlexiObject.AppClient.ViewModels;

using System;
using FlexiObject.Core.Config;

namespace FlexiObject.AppClient
{
    public class ViewLocator : IDataTemplate
    {
        private readonly IContainer _container;
        public ViewLocator(IContainer container)
        {
            _container = container;
        }
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return _container.Get<IControl>(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
