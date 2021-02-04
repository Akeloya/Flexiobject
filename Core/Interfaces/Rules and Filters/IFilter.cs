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
    /// Фильтр данных папки
    /// </summary>
    public interface IFilter : IBase
    {
        /// <summary>
        /// Коллекция пользовательских полей для управления фильтрацией
        /// </summary>
        IFilterFieldIndexer UserField { get; }
        /// <summary>
        /// Правило фильтрации данных
        /// </summary>
        IRule Rule { get; set; }
        /// <summary>
        /// Доступ к оператору сравнения данных поля
        /// </summary>
        IFilterFieldCompatisonIndexer UserFieldComparison { get; }
        /// <summary>
        /// Папка в которой выполняется фильтрация
        /// </summary>
        IRequestFolder Folder { get; }
        /// <summary>
        /// Комбинирование фильтров данных
        /// </summary>
        /// <param name="filter">Фильтр с которым комбинируется текущий фильтр</param>
        /// <param name="term">Правило комбинирования фильтра И/ИЛИ</param>
        void Combine(IFilter filter, CoaRuleCombinationTerms term);
        /// <summary>
        /// Сохранение фильтра на сервер
        /// </summary>
        void Save();
    }
}