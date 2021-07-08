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
    /// Exception for link rule check
    /// </summary>
    [Serializable]
    public class RestrictionRuleFailedException : CoaApplicationException
    {
        /// <summary>
        /// Standard constructor
        /// </summary>
        public RestrictionRuleFailedException() : base(Resource.RestrictionRuleFailedException, AppExceptionStatus.Work)
        {

        }
        /// <summary>
        /// Standard constructor with inner exception link
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        public RestrictionRuleFailedException(Exception innerException) : base(Resource.RestrictionRuleFailedException, innerException, AppExceptionStatus.Work)
        {

        }
        /// <summary>
        /// Constructor for override exception message text
        /// </summary>
        /// <param name="message">Exception message</param>
        public RestrictionRuleFailedException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Constructor for override exception message with inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception link</param>
        public RestrictionRuleFailedException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
    }
}
