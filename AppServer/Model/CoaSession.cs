using CoaApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServer.Model
{
    public class CoaSession : Session
    {
        internal CoaSession(CoaApplication app) : base(app)
        {

        }
    }
}
