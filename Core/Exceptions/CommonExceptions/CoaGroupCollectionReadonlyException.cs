/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
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
    /// 
    /// </summary>
    [Serializable]
    public class CoaGroupCollectionReadonlyException : CoaApplicationException
    {
        /// <summary>
        /// Standard constructor with predefined exception message
        /// </summary>
        public CoaGroupCollectionReadonlyException() : base(Resource.CoaGroupCollectionReadonlyException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Standard coustructor with predefined exception message and additional exception object
        /// </summary>
        /// <param name="innerException">Additional exception object</param>
        public CoaGroupCollectionReadonlyException(Exception innerException) : 
            base(Resource.CoaGroupCollectionReadonlyException, 
                innerException, 
                AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor for override exception message with additional exception object
        /// </summary>
        /// <param name="message">Custom exception message</param>
        /// <param name="innerException">Additional exception object</param>
        public CoaGroupCollectionReadonlyException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor for override exception message
        /// </summary>
        /// <param name="message">Custom exception message</param>
        public CoaGroupCollectionReadonlyException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
    }
}
