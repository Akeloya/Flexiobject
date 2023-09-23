namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Результат запроса к данным
    /// </summary>
    public interface IQueryResult : IBase
    {
        /// <summary>
        /// Количество колонок в результатах запроса
        /// </summary>
        int ColumnCount { get; }
        /// <summary>
        /// Колонка в результатах запроса
        /// </summary>
        /// <param name="index">индекс колонки</param>
        /// <returns>Имя колонки</returns>
        IQueryResultColumn this[int index] { get; }
        /// <summary>
        /// Количество строк в результатах запроса
        /// </summary>
        int Rows { get; }
        /// <summary>
        /// Значение
        /// </summary>
        /// <param name="row">индекс строки</param>
        /// <param name="col">индекс колонки</param>
        /// <returns></returns>
        object this[int row, int col] { get; }
    }
}