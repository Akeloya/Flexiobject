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
    /// Exception thowns when saving CoaUser object without password, but it must be
    /// </summary>
    [Serializable]
    public class CoaUserPasswordRequiredException : CoaApplicationException
    {
        /// <summary>
        /// Default exception constructor with predefined message
        /// </summary>
        public CoaUserPasswordRequiredException() : base(Resource.CoaUserPasswordRequiredException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor with overriding exception message
        /// </summary>
        /// <param name="message">Custom exception message</param>
        public CoaUserPasswordRequiredException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor with overriding exception message and inner exception
        /// </summary>
        /// <param name="message">Custom exception message</param>
        /// <param name="innerException">Additional exception</param>
        public CoaUserPasswordRequiredException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Default constructor with additional exception object and predefined exception message
        /// </summary>
        /// <param name="innerException"></param>
        public CoaUserPasswordRequiredException(Exception innerException) : base(Resource.CoaUserPasswordRequiredException, innerException, AppExceptionStatus.Work)
        {

        }
    }
}
