using System;

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

    public class DatabaseNotEmptyException : ApplicationException
    {

    }
}
