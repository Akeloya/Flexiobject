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
    /// Определение пользовательского поля
    /// </summary>
    public interface IUserFieldDefinition : IBase
    {
        /// <summary>
        /// Ид определения
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Алиас определения
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Название пользовательского определения
        /// </summary>
        string Label { get; set; }
        /// <summary>
        /// Детали пользовательского определения
        /// </summary>
        dynamic Details { get; }
        /// <summary>
        /// Тип пользовательского определения
        /// </summary>
        CoaFieldTypes Type { get; set; }
        /// <summary>
        /// Необходимость записывать в историю изменения значения поля объекта
        /// </summary>
        bool WriteHistory { get; set; }
        /// <summary>
        /// Значение по умолчанию. Для даты подробности получения значения по умолчанию определяются в деталях
        /// </summary>
        object DefaultValue { get; set; }
        /// <summary>
        /// Вычисление необходимости установить значение в поле
        /// </summary>
        /// <param name="oldReq">Копия объекта до изменения</param>
        /// <param name="newReq">Копия объекта после изменения</param>
        /// <returns>истина/ложь</returns>
        bool IsRequired(ICustomObject oldReq, ICustomObject newReq);
        /// <summary>
        /// Доступно ли поле для использования
        /// </summary>
        /// <param name="oldReq"></param>
        /// <param name="newReq"></param>
        /// <returns></returns>
        bool IsEnabled(ICustomObject oldReq, ICustomObject newReq);
        /// <summary>
        /// Возможна ли смена типа поля
        /// </summary>
        bool CanEditFieldType { get; }
        /// <summary>
        /// Необходим ли использовать правило обязательности заполнения данных
        /// </summary>
        bool UseRuleRequired { get; set; }
        /// <summary>
        /// Доступно ли поле для редактирования
        /// </summary>
        bool UseRuleEnabled { get; set; }
        /// <summary>
        /// Правило обязательности заполнения
        /// </summary>
        IRule RequiredRule { get; set; }
        /// <summary>
        /// Правило доступности редактирования
        /// </summary>
        IRule EnabledRule { get; set; }
        /// <summary>
        /// Индекс в БД
        /// </summary>
        bool IndexFieldDb { get; set; }
        /// <summary>
        /// Индекс поля
        /// </summary>
        bool IndexField { get; set; }
        /// <summary>
        /// Сохранение измений
        /// </summary>
        void Save();
    }
}