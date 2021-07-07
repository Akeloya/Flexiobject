/*
 *  "Custom object application core"
 *  An application that implements the ability to customize object templates and actions on them.
 *  Copyright (C) 2018 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using CoaApp.Core.Properties;
using System;
;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Scheme history argument exception
    /// </summary>
    [Serializable]
    public class SchemaHistoryArgumentException : CoaApplicationException
    {
        /// <summary>
        /// overriding base exception message and add inner exception
        /// </summary>
        /// <param name="message">New message text</param>
        /// <param name="innerException">Inner exception</param>
        public SchemaHistoryArgumentException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Default counstructor with predefined exception message
        /// </summary>
        public SchemaHistoryArgumentException() : base(Resource.SchemaHistoryArgumentException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Schema history exception with argument name
        /// </summary>
        /// <param name="argumentName">Name of invalid argument</param>
        public SchemaHistoryArgumentException(string argumentName) : base(string.Format(Resource.SchemaHistoryArgumentExceptionWithArgName, argumentName), AppExceptionStatus.Work)
        {

        }
    }
}
