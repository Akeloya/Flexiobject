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
    /// Группа доступа
    /// </summary>
    public interface IGroup : IBase
    {
        /// <summary>
        /// Идентификатор группы доступа
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Название группы
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Отображаемое имя группы
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Почтовый адрес группы
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// Настройки отправки почтовых уведомлений на группу и пользователей
        /// </summary>
        CoaGroupBehaviorTypes EmailBehavior { get; set; }
        /// <summary>
        /// Дочерние группы
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Получение списка дочерних групп рекурсивно в глубину
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Связанный IRequest объект группы доступа
        /// </summary>
        ICustomObject Object { get; }
        /// <summary>
        /// Члены группы
        /// </summary>
        IUsers Users { get; }
        /// <summary>
        /// Список членов группы рекурсивно в глубину
        /// </summary>
        IUsers UsersRecurcive { get; }
        /// <summary>
        /// Добавить дочернюю группу
        /// </summary>
        /// <param name="group">IGroup добавляемая группа</param>
        void AddGroup(IGroup group);
        /// <summary>
        /// Добавление нового члена группы
        /// </summary>
        /// <param name="user">IUser член группы</param>
        void AddUser(IUser user);
        /// <summary>
        /// Проверка нахождения группы в дочерних группах
        /// </summary>
        /// <param name="groupName">Название проверяемой группы</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Проверка нахождения группы в дочерних группах рекурсивно в глубину
        /// </summary>
        /// <param name="groupName">Название проверяемой группы</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Удаление группы из списка дочерних групп
        /// </summary>
        /// <param name="group">Удаляемая группа</param>
        void RemoveGroup(IGroup group);
        /// <summary>
        /// Удаление пользователя из списка членов группы
        /// </summary>
        /// <param name="user">IUser удаляемый пользователь</param>
        void RemoveUser(IUser user);
        /// <summary>
        /// Удалить объект
        /// </summary>
        void Delete();
        /// <summary>
        /// Сохранить изменения в объекте
        /// </summary>
        void Save();
        /// <summary>
        /// Отправить e-mail сообщение на указанный адрес
        /// <seealso cref="EmailAddress"/> 
        /// </summary>
        void SendEmail();
    }
}