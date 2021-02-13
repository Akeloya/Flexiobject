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

using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Пользователь приложения
    /// </summary>
    public interface IUser : IBase
    {
        /// <summary>
        /// Флаг состояния объекта. Активный - используется для входа в приложение, нет - не используется
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// Папка по умолчанию. Используется вместе с <see cref="HasDefaultRequestFolder"/> и указывает папку, по умолчанию при открытии приложения для пользователя
        /// </summary>
        ICustomFolder DefaultRequestFolder { get; set; }
        /// <summary>
        /// Подразделение пользователя
        /// </summary>
        string Department { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Имя домена
        /// </summary>
        string DomainName { get; set; }
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// Коллекция групп, в которую непосредственно включен пользователь
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Все группы пользователя, включая вложенные
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Имеется ли у пользователя папка по умолчанию.
        /// <see cref="DefaultRequestFolder"/>
        /// </summary>
        bool HasDefaultRequestFolder { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// Ссылка на LDAP профиль
        /// </summary>
        string LdapProfile { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        string LoginName { get; set; }
        /// <summary>
        /// Название объекта
        /// </summary>
        string Name { get; }
        /// <summary>
        /// IRequest связанный объект текущего объекта IUser
        /// </summary>
        ICustomObject Object { get; }
        /// <summary>
        /// Аккаунт эл. почты для исходящих сообщений
        /// </summary>
        string OutgoingEmailAccount { get; set; }
        /// <summary>
        /// Пароль в зашифрованном виде
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Телефон пользователя
        /// </summary>
        string Phone { get; set; }
        /// <summary>
        /// Флаг привелегий супер пользователя
        /// </summary>
        bool SuperUser { get; set; }
        /// <summary>
        /// Уникальный ИД пользователя
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Способ входа в систему.
        /// </summary>
        CoaUserAuthenticationTypes AuthenticationType { get; set; }
        /// <summary>
        /// Добавить пользователя в группу
        /// </summary>
        /// <param name="group">Группа, в которую добавляется пользователь</param>
        void AddToGroup(IGroup group);
        /// <summary>
        /// Проверка принадлежности пользователя к группе
        /// </summary>
        /// <param name="groupName">Имя группы для проверки принадлежности</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Рекурсивная проверка принадлежности пользователя к группе
        /// </summary>
        /// <param name="groupName">Имя группы для проверки принадлежности</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Сохранить изменения объекта
        /// </summary>
        void Save();
        /// <summary>
        /// Удалить пользователя из базы данных
        /// </summary>
        void Delete();
    }
}