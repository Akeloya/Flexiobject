using System;
using System.Collections.Generic;
using System.ComponentModel;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Код (скрипт) c# для выполнения
    /// </summary>
    public interface IScript : IBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Ид скрипта
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Скрипт/код
        /// </summary>
        string Script { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        FlexiScriptTypes Type { get; set; }
        /// <summary>
        /// Ссылка на форме
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// Флаг построения скрипта
        /// </summary>
        bool Builded { get; }
        /// <summary>
        /// Сохранение изменений с построением
        /// </summary>
        /// <returns>Список ошибок при построении</returns>
        List<string> Save();
        /// <summary>
        /// Построение или перестроение скрипта
        /// </summary>
        /// <returns>Ошибки, возникшие во время построения</returns>
        List<string> Build();
        /// <summary>
        /// Публикация версии в качестве текущей
        /// </summary>
        /// <returns>Список ошибок, либо null. Если имеется список ошибок, то публикация провалилась.</returns>
        List<string> Publish();
            /// <summary>
        /// Последнее время построения
        /// </summary>
        DateTime? BuildedTime { get;}     
        /// <summary>
        /// Ошибки построения скрипта
        /// </summary>
        List<string> Errors { get; }
        /// <summary>
        /// Папка скрипта
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// История изменения скрипта
        /// </summary>
        IScriptHistoryItems HistoryItems { get; }
    }
}