using AppClient.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClient.ViewModels
{
    public class SettingsViewModel
    {
        public IJsonConfiguration _configuration;
        public SettingsViewModel(IJsonConfiguration jsonConfiguration)
        {
            _configuration = jsonConfiguration;
        }
    }
}
