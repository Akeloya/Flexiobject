using System;

namespace Flexiobject.API.Transport
{
    internal class ClientFactory
    {
        private static readonly ClientFactory _instanse = new();
        private Lazy<Client> _clientInst = new Lazy<Client>(()=> new Client());

        static ClientFactory()
        {

        }
        internal Client GetSinglton() => _clientInst.Value;
        public static ClientFactory Instance => _instanse;

    }
}
