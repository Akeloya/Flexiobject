namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение именованного правила
    /// </summary>
    public interface INamedFilterDefinition : IBase
    {
        /// <summary>
        /// Описание фильтра
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        IFilter Filter { get; }
        /// <summary>
        /// Имя фильтра
        /// </summary>
        string Name { get; set; }        
        /// <summary>
        /// Общий фильтр или личный
        /// </summary>
        bool Public { get; set; }
    }
}