/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Base typed object collection
    /// </summary>
    public interface IBaseCollection<T>
    {
        /// <summary>
        /// Acces object in collection by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// Access object in collection by name or string key
        /// </summary>
        /// <param name="name">Name of object or string key</param>
        /// <returns></returns>
        T this[string name] { get; }
        /// <summary>
        /// Add new object to collection 
        /// </summary>
        /// <returns>Created object. Object will be added to collection after it saved</returns>
        T Add();
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="obj">Object for removing</param>
        void Remove(T obj);
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="index">Index number for removing object</param>
        void Remove(int index);
        /// <summary>
        /// Object collection count 
        /// </summary>
        int Count { get; }
    }
}
