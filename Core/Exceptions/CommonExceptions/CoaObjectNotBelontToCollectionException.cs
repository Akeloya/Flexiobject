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
    /// Object not belong to collection exception
    /// </summary>
    [Serializable]
    public class CoaObjectNotBelontToCollectionException : CoaApplicationException
    {
        /// <summary>
        /// Constructor for override exception message
        /// </summary>
        /// <param name="message">Exception message</param>
        public CoaObjectNotBelontToCollectionException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor for override exception message with additional exception object
        /// </summary>
        /// <param name="message">Custom exception message</param>
        /// <param name="innerException">Additional exception object</param>
        public CoaObjectNotBelontToCollectionException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Default exception constructor
        /// </summary>
        public CoaObjectNotBelontToCollectionException() : base(Resource.CoaObjectNotBelontToCollectionException, AppExceptionStatus.Work)
        {
        }
    }
}
