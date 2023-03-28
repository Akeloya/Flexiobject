using System.Collections.Generic;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция скриптов (модулей кода)
    /// </summary>
    public interface IScripts : IBase
    {
        /// <summary>
        /// Добавление нового скрипта
        /// </summary>
        /// <returns></returns>
        IScript Add();
        /// <summary>
        /// Создание нового скрипта с шаблоном текста согласно указанному типу
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IScript Add(FlexiScriptTypes type);
        /// <summary>
        /// Удаление скрипта по его ИД
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);
        /// <summary>
        /// Количество скриптов в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к скрипту по его ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IScript this [int id] { get; }
        /// <summary>
        /// Заглушка
        /// </summary>
        List<IScript> List { get; } 
    }
}