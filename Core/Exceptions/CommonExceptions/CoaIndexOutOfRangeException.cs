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
    /// Index out of range exception in applications object collections
    /// </summary>
    [Serializable]
    public class CoaIndexOutOfRangeException : CoaApplicationException
    {
        /// <summary>
        /// Standard constructor with definiton type index out of range exception
        /// </summary>
        /// <param name="collectonType">Collection type string</param>
        public CoaIndexOutOfRangeException(string collectonType) : base(
            string.Format(Resource.CoaIndexOutOfRangeException_CollectionType, collectonType),
            AppExceptionStatus.Terminate)
        {
        }
        /// <summary>
        /// Constructor with definition type index out of range exception and additional exception object
        /// </summary>
        /// <param name="collectonType">Collection type string</param>
        /// <param name="innerException">Additional exception object</param>
        public CoaIndexOutOfRangeException(string collectonType, Exception innerException) : base(
            string.Format(Resource.CoaIndexOutOfRangeException_CollectionType, collectonType),
            innerException,
            AppExceptionStatus.Terminate)
        {
        }
        /// <summary>
        /// Constructor with standard exception string and additional exception object
        /// </summary>
        /// <param name="innerException">Additional exception object</param>
        public CoaIndexOutOfRangeException(Exception innerException) : base(Resource.CoaIndexOutOfRangeException, innerException, AppExceptionStatus.Terminate)
        {

        }
        /// <summary>
        /// Standard constructor
        /// </summary>
        public CoaIndexOutOfRangeException() : base(Resource.CoaIndexOutOfRangeException, AppExceptionStatus.Terminate)
        {
        }
    }
}
