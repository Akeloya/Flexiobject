using AppClient.Services;
using AppClient.ViewModels;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using System;

namespace AppClient
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
                var control =  _container.Get<IControl>(type);
                control.DataContext = data;//TODO realy need it here?
                return control;
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
