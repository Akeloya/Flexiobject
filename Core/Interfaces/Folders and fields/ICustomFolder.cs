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
using System.Collections.Generic;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User object folder
    /// </summary>
    public interface ICustomFolder : IBase
    {
        /// <summary>
        /// Unique folder identifier
        /// <seealso cref="ISession.GetRequestFolderByUniqueId(int)"/>
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Folder name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Folder alias
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Object naming scheme inheritance flag
        /// </summary>
        bool InheritNamingScheme { get; set; }
        /// <summary>
        /// Object naming scheme
        /// <seealso cref="ICustomObject.Name"/>
        /// </summary>
        string NamingScheme { get; set; }
        /// <summary>
        /// Folder path
        /// <seealso cref="ISession.GetRequestFolderByPath(string)"/>
        /// </summary>
        string Path { get; }
        /// <summary>
        /// Collection of folder forms
        /// </summary>
        IForms Forms { get; }
        /// <summary>
        /// Parent folder link
        /// </summary>
        ICustomFolder ParentFolder { get; }
        /// <summary>
        /// Действия после создания объекта
        /// </summary>
        IActions AfterCreateActions { get; }
        /// <summary>
        /// Действия после удаления объекта
        /// </summary>
        IActions AfterDeleteActions { get; }
        /// <summary>
        /// Действия после изменения объекта
        /// </summary>
        IActions AfterModificationActions { get; }
        /// <summary>
        /// Действия до создания объекта
        /// </summary>
        IActions BeforCreateActions { get; }
        /// <summary>
        /// Действия до удаления объекта
        /// </summary>
        IActions BeforDeleteActions { get; }
        /// <summary>
        /// Действия до изменения объекта
        /// </summary>
        IActions BeforModificationActions { get; }
        /// <summary>
        /// Привилегии доступа к объектам папки и ее настройкам
        /// </summary>
        IPrivileges Privileges { get; }
        /// <summary>
        /// Folder open (select) picture
        /// </summary>
        IPicture PictureOpen { get; set; }
        /// <summary>
        /// Folder close (not select) picture
        /// </summary>
        IPicture PictureClose { get; set; }
        /// <summary>
        /// Folder objects collection
        /// </summary>
        ICustomObjects Requests { get; }
        /// <summary>
        /// Folder scrip collection
        /// </summary>
        IScripts Scripts { get; }
        /// <summary>
        /// Определение пользовательских полей папки
        /// </summary>
        IUserFieldDefinitions UserFieldDefinitions { get; }
        /// <summary>
        /// Создание нового фильтра
        /// </summary>
        /// <returns>IFilter объект для фильтрации данных текущей папки</returns>
        IFilter MakeFilter();
        /// <summary>
        /// Дочерние папки
        /// </summary>
        ICustomFolders SubFolders { get; }
        /// <summary>
        /// Автоматические вычисления над данными объектов в папке
        /// </summary>
        IAutocalculations Autocalculations { get; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        void Save();
        /// <summary>
        /// Изменение положения папки в дереве папок
        /// </summary>
        /// <param name="folder">Новая родительская папка</param>
        void Move(ICustomFolder folder);
        /// <summary>
        /// Создание пустого отображения списка
        /// </summary>
        /// <returns></returns>
        IColumnLayout MakeColumnLayout();
        /// <summary>
        /// Получение текущего отображения списка
        /// </summary>
        /// <returns></returns>
        IColumnLayout GetColumnLayout();
        /// <summary>
        /// Поиск объектов с фильтром
        /// </summary>
        /// <param name="filter">Фильтр для папки</param>
        /// <returns></returns>
        ICustomObjects Search(IFilter filter);
        /// <summary>
        /// Установка отображения списка текущим
        /// </summary>
        /// <param name="layout"></param>
        void SetColumnLayout(IColumnLayout layout);
        /// <summary>
        /// Устанавливает идентификатор текущего отображения для текущего пользователя и контекст.
        /// </summary>
        /// <param name="context">Контекст для текущего отображения</param>
        /// <param name="viewId">Ид отображения, который должен быть текущим</param>
        void SetCurrentView(int context, int viewId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="type">
        /// 0 = Any type
        /// 1 = Request List
        /// 2 = Calendar(Month)
        /// 3 = Calendar(Week)
        /// 4 = Calendar(Day)
        /// 5 = Tree
        /// </param>
        /// <returns></returns>
        IView GetInitialView(int context, int type = 0);
        /// <summary>
        /// Создание нового физуального представления для текущей папки
        /// </summary>
        /// <returns>IView объект</returns>
        IView MakeView();
        /// <summary>
        /// Создание новых настроек импорта данных
        /// </summary>
        /// <returns>Объект настроек</returns>
        IImportDefinition MakeImportDefinition();
        /// <summary>
        /// Удаление настроек импорта данных
        /// </summary>
        /// <param name="settings">название или объект удаляемой настройки IImportDefinition</param>
        void DeleteImportDefinition(object settings);
        /// <summary>
        /// Создание импорта данных из настроек
        /// </summary>
        /// <returns></returns>
        IImport MakeImport();
        /// <summary>
        /// Создание нового запроса к данным
        /// <seealso cref="IQuery"/>
        /// </summary>
        /// <returns></returns>
        IQuery MakeQuery();
        
        /// <summary>
        /// Получить уровень привилегий пользователя для папки
        /// </summary>
        /// <param name="user">Пользователь, для которого происходит проверка</param>
        /// <returns>Уровень привелегий, см <see cref="CoaEnumPermissionDefinition"/></returns>
        CoaEnumPrivilegeLevel GetPrivilegeLevel(IUser user);
        /// <summary>
        /// Получить уровень привилегий группы для папки
        /// </summary>
        /// <param name="group">Группа, для которого происходит проверка</param>
        /// <returns>Уровень привелегий, см <see cref="CoaEnumPermissionDefinition"/></returns>
        CoaEnumPrivilegeLevel GetPrivilegeLevel(IGroup group);
        /// <summary>
        /// Правило видимости папки
        /// </summary>
        IRule VisibilityRule { get; set; }
        /// <summary>
        /// Установка связи с папкой приложения
        /// </summary>
        /// <param name="type">Тип папки</param>
        /// <returns></returns>
        bool this[CoaApplicationFolders type] { get;set; }
        /// <summary>
        /// Установка связи пользовательского поля и поля приложения
        /// </summary>
        /// <param name="folderType"></param>
        /// <param name="propType"></param>
        /// <returns></returns>
        IUserFieldDefinition this[CoaApplicationFolders folderType, CoaApplicationFoldersProperties propType] { get; set; }
        /// <summary>
        /// Получение истории изменения схемы
        /// </summary>
        ISchemaHistory SchemaHistory { get; }
        /// <summary>
        /// Поле рабочего процесса, задействованное в истории
        /// </summary>
        IUserFieldDefinition HistoryWorkflowField { get; set; }
    }
}