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
using System.Collections.Generic;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Автокалькуляция на папке
    /// </summary>
    public interface IAutocalculation : IBase
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Тип автокалькуляции
        /// </summary>
        CoaSummaryTypes AutoCalculationType { get; set; }
        /// <summary>
        /// Флаги состояния модификации автокалькуляции
        /// </summary>
        CoaExecutionFlags Flags { get; set; }
        /// <summary>
        /// Скрипт расчета
        /// </summary>
        IScript Script { get; set; }
        /// <summary>
        /// Фильтр дополнительной фильтрации объектов автокалькуляции
        /// </summary>
        IRule SummarisingFilter { get; set; }
        /// <summary>
        /// Поля хранения данных
        /// </summary>
        IUserFieldDefinitions DataStoredFields { get; set; }
        /// <summary>
        /// Поля от которых зависит расчет калькуляции скриптом
        /// </summary>
        List<string> ScriptDependencyFields { get; set; }
        /// <summary>
        /// Поле типа "ObjectList" с объектами для калькуляции
        /// <seealso cref="CoaEnumFieldType"/>
        /// <seealso cref="IUserFieldDefinition"/>
        /// <seealso cref="SummarizedFieldPath"/>
        /// </summary>
        IUserFieldDefinition ObjectsStoredField { get; set; }        
        /// <summary>
        /// Путь к полю, в котором содержатся данные
        /// </summary>
        string SummarizedFieldPath { get; set; }
        /// <summary>
        /// Хранить 0 вместо "пусто"
        /// </summary>
        bool StoreZero { get; set; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        void Save();
        /// <summary>
        /// Пересчет автокалькуляции        
        /// </summary>
        /// <param name="variant">Объект IRequest для которого производится пересчет или IRequests для которых проводится пересчет</param>
        void Recalc(object variant);
    }
}