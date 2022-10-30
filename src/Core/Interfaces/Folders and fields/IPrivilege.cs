/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Разрешения для группу или пользователя, связанные с папкой
    /// </summary>
    public interface IPrivilege : IBase
    {
        /// <summary>
        /// Флаг, определяющий правила применения привилегий.
        /// true - если привилегия применяется для всех пользователей. Тогда поле <see cref="User"/> будет null
        /// false - если привилегия применяется для пользователей указанных в <see cref="User"/>
        /// </summary>
        bool AllUsers { get; set; }
        /// <summary>
        /// Флаг наследована ли привелегия от родительской папки
        /// </summary>
        bool Inherited { get; }
        /// <summary>
        /// true - если привилегия использована для группы
        /// false - для пользователя
        /// </summary>
        bool IsGroup { get; }
        /// <summary>
        /// Уровень привилегии для пользователя или группы
        /// </summary>
        CoaEnumPrivilegeLevel PrivilegeLevel { get; set; }
        /// <summary>
        /// Пользователь или группа, для которого применяется привилегия.
        /// Возвращается объект <see cref="IUser"/> или <see cref="IGroup"/>.
        /// Для уточнения поспользуйтесь <see cref="IsGroup"/>
        /// </summary>
        dynamic User { get; set; }
        /// <summary>
        /// Сохранение изменение разрешения
        /// </summary>
        void Save();
    }
}
