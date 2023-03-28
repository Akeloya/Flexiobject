using FlexiObject.Core.Enumes;
using System.Drawing;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс формы приложения
    /// </summary>
    public interface IForm : IBase
    {
        /// <summary>
        /// Название формы в БД
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Заголовок формы в ПИ
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Ширина окна формы
        /// </summary>
        double Width { get; set; }
        /// <summary>
        /// Высота окна формы
        /// </summary>
        double Height { get; set; }
        /// <summary>
        /// Содержимое формы
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Фон формы
        /// </summary>
        Color? Background { get; set; }
        /// <summary>
        /// Папка принадлежности формы, пусто - если форма глобальная
        /// </summary>        
        ICustomFolder Folder { get; }
        /// <summary>
        /// Скрипт, вызываемый при открытии формы
        /// </summary>
        IScript OnOpenScript { get; set; }
        /// <summary>
        /// Скрипт вызываемый при закрытии формы
        /// </summary>
        IScript OnCloseScript { get; set; }
        /// <summary>
        /// Тип формы
        /// </summary>
        FlexiFormTypes Type { get; }
        /// <summary>
        /// Сохранение изменений в форме, при ее изменении
        /// </summary>
        void Save();
    }
}
