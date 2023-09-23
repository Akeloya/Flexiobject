using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Объект представляет объект IView (вывод может быть в виде списка, календаря, дерева)
    /// </summary>
    public interface IViewLayout : IBase
    {
        /// <summary>
        /// Папка визуального отображения данных
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// Название вида
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Тип вида
        /// </summary>
        FlexiViewTypes Type { get; set; }
        /// <summary>
        /// Добавить колонку к табличному виду
        /// </summary>
        /// <param name="column">Колонка</param>
        void AddColumnLayout(IColumnLayout column);
        /// <summary>
        /// Добавить колонку к древовидному виду.
        /// </summary>
        /// <param name="tree">Колонка</param>
        void AddTreeLayout(ITreeLayout tree);
        /// <summary>
        /// Получить табличное представление по папке и контексту
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IColumnLayout GetColumnLayout(int folderId, int context);
        /// <summary>
        /// Получить древовидное представление по папке и контексту
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        ITreeLayout GetTreeLayout(int folderId, int context);
        /// <summary>
        /// Заменить пользовательское поле
        /// </summary>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        /// <returns></returns>
        long ReplaceUserfield(object oldVal, object newVal);
        /// <summary>
        /// Сохранить представление
        /// </summary>
        void Save();
    }
}