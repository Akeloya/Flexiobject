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
namespace FlexiObject.Core.Interfaces
{
    public interface ISession : IBase
    {
        /// <summary>
        /// Список всех папок
        /// </summary>
        ICustomFolders RequestFolders { get; }

        /// <summary>
        /// Сессии пользователей
        /// </summary>
        IActiveSessions ActiveSessions { get; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Коллекция картинок, доступных на сервере
        /// </summary>
        IPictures Pictures { get; }
        /// <summary>
        /// Активный пользователь
        /// </summary>
        IUser ActiveUser { get; }
        /// <summary>
        /// Группы приложения, включая группу
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Пользователи приложения. По умолчанию возвращаются активные пользователи. Если сессия открыта от суперпользователя, то будут возвращены все пользователи, включая неактивных.
        /// </summary>
        IUsers Users { get; }
        /// <summary>
        /// завершить текущую сессию и закрыть подключение к серверу
        /// </summary>
        void Logoff();

        /// <summary>
        /// Удаленные объекты, находящиеся в корзине
        /// </summary>
        /// <returns>IRequests коллекция удаленных объектов, находящихся в корзине</returns>
        ICustomObjects GetDeletedRequests();

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор объекта</param>
        /// <returns>null/IRequest</returns>
        ICustomObject GetRequestByUniqueId(long id);
        /// <summary>
        /// Запланированные задачи на сервере
        /// </summary>
        IScheduledTasks ScheduledTasks { get; }
        /// <summary>
        /// Получить папку по ее пути
        /// </summary>
        /// <param name="path">Папка[\подпапка 1]</param>
        /// <returns></returns>
        ICustomFolder GetRequestFolderByPath(string path);

        /// <summary>
        /// Получить папку по ее идентификатору
        /// </summary>
        /// <param name="id">Ид папки</param>
        /// <returns>null/IRequestFolder</returns>
        ICustomFolder GetRequestFolderByUniqueId(int id);

        /// <summary>
        /// Логирование сообщения
        /// </summary>
        /// <param name="msg">Сообщение для логирвоания</param>
        void LogMessage(string msg);
        /// <summary>
        /// Получение системного параметра
        /// </summary>
        /// <param name="table">Таблица параметров</param>
        /// <param name="name">Имя параметра</param>
        /// <returns>Строка-значение параметра</returns>
        string GetSystemParameter(string table, string name);
        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id">Ид пользователя</param>
        /// <returns>null/IUser</returns>
        IUser GetUserByUniqueId(int id);
        /// <summary>
        /// Получить группу
        /// </summary>
        /// <param name="id">ИД группы</param>
        /// <returns>Группа пользователей. <see cref="IGroup"/></returns>
        IGroup GetGroupByUniqueId(int id);
        /// <summary>
        /// Получить серверный скрипт по имени
        /// </summary>
        /// <param name="name">Имя скрипта</param>
        /// <returns>IScript/null</returns>
        IScript GetServerScript(string name);
        /// <summary>
        /// Получить состояние по ИД
        /// </summary>
        /// <param name="id">Идентификатор состояния</param>
        /// <returns></returns>
        IState GetStateByUniqueId(int id);
        /// <summary>
        /// Уведомление пользователя
        /// </summary>
        /// <param name="reciever">Получатель, объект IUser или IRequest, связанный с пользователями приложения</param>
        /// <param name="message">Сообщение</param>
        /// <param name="linkedRequest">Ссылка на объект при необходимости</param>
        void NotifyUser(object reciever, string message, ICustomObject linkedRequest);
        /// <summary>
        /// Получить определение пользовательского поля по идентификатору
        /// </summary>
        /// <param name="id">Ид поля</param>
        /// <returns>IUserFieldDefinition/null</returns>
        IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id);
        /// <summary>
        /// Пользовательский запрос к данным
        /// </summary>
        /// <param name="sqlCommand">Строка</param>
        /// <param name="parameters">Параметры запроса</param>
        /// <returns></returns>
        IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters);
        /// <summary>
        /// Получение визуального представления по ИД
        /// </summary>
        /// <param name="id">Ид искомого представления</param>
        /// <returns></returns>
        IView GetViewByUniqueId(int id);
    }
}
