using CoaApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServer.Model
{
    public class CoaUser : User
    {
        internal CoaUser(CoaApplication app, Session parent): base(app, parent)
        {

        }
    }
}
