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

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception class for detecting problem or error on form
    /// </summary>
    [Serializable]
    public class CoaProblemOnFormException : CoaApplicationException
    {
        /// <summary>
        /// Constructor for custom message exception
        /// </summary>
        /// <param name="message">Custom message exception</param>
        public CoaProblemOnFormException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor for custom exception message and exception object
        /// </summary>
        /// <param name="message">Custom message exception</param>
        /// <param name="innerException">Additional exception object</param>
        public CoaProblemOnFormException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public CoaProblemOnFormException() : base(Resource.CoaProblemOnFormException, AppExceptionStatus.Work)
        {
        }
    }
}
