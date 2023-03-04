using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiObject.Core.Exceptions
{
    public class ApplicationException : Exception
    {
    }

    public class UnauthorizedException : ApplicationException
    {

    }

    public class ObjectNotFoundException : ApplicationException
    {

    }

    public class ObjectAlreadyExistsException : ApplicationException
    {

    }
}
