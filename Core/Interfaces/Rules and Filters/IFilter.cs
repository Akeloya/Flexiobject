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
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Filter data in objects
    /// </summary>
    public interface IFilter : IBase
    {
        /// <summary>
        /// User field for filter data
        /// </summary>
        IFilterFieldIndexer UserField { get; }
        /// <summary>
        /// Filtering rule
        /// </summary>
        IRule Rule { get; set; }
        /// <summary>
        /// User field comparison
        /// </summary>
        IFilterFieldCompatisonIndexer UserFieldComparison { get; }
        /// <summary>
        /// Folder of filter
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// Combining two filter in one
        /// </summary>
        /// <param name="filter">The filter with which the current filter is combined</param>
        /// <param name="term">Filter combination rule AND / OR</param>
        void Combine(IFilter filter, CoaRuleCombinationTerms term);
        /// <summary>
        /// Save filter
        /// </summary>
        void Save();
    }
}