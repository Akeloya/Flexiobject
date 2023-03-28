namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция папкок
    /// </summary>
    public interface ICustomFolders : IBaseCollection<ICustomFolder>
    {
        /// <summary>
        /// Добавить новую папку
        /// </summary>
        /// <param name="name">Имя папки</param>
        /// <param name="alias">Алиас папки</param>
        /// <param name="parentFolder">Родительская папка</param>
        /// <returns></returns>
        ICustomFolder Add(string name, string alias, ICustomFolder parentFolder);
        /// <summary>
        /// Удаление папки
        /// </summary>
        /// <param name="id">Ид папки</param>
        /// <param name="force">Игнорировать наличие в папке объектов</param>
        void Remove(int id, bool force = false);
        /// <summary>
        /// Удаление папки
        /// </summary>
        /// <param name="folder">Папка для удаления</param>
        /// <param name="force">Игнорирование наличия в папке объектов</param>
        void Remove(ICustomFolder folder, bool force = false);
        /// <summary>
        /// Доступ к элементу коллекции по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор папки</param>
        /// <returns>IRequestFolder/null</returns>
    }
}