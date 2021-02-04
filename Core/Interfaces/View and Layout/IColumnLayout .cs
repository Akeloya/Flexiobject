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
    /// Представление настроек отображение списка объектов
    /// </summary>
    public interface IColumnLayout : IBase
    {
        /// <summary>
        /// Количество колонок в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Добавление новой колонки
        /// </summary>
        /// <param name="type">Тип колонки</param>
        /// <param name="field">Путь к полю</param>
        /// <param name="width">Визуальная ширина</param>
        /// <param name="header">Название</param>
        void AddColumn(CoaColumnType type, string field, int width, string header);
        /// <summary>
        /// Получить поле колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        string GetColumnField(int index);
        /// <summary>
        /// Получить название колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        string GetColumnHeaderName(int index);
        /// <summary>
        /// Получить тип колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        CoaColumnType GetColumnType(int index);
        /// <summary>
        /// Получить ширину колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        int GetColumnWidth(int index);
        /// <summary>
        /// Удалить колонку
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        void RemoveColumn(int index);

    }
}