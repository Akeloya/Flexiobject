using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Группа доступа
    /// </summary>
    public interface IGroup : IBase
    {
        /// <summary>
        /// Идентификатор группы доступа
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Название группы
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Отображаемое имя группы
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Почтовый адрес группы
        /// </summary>
        string EmailAddress { get; set; }
        /// <summary>
        /// Настройки отправки почтовых уведомлений на группу и пользователей
        /// </summary>
        FlexiGroupBehaviorTypes EmailBehavior { get; set; }
        /// <summary>
        /// Дочерние группы
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Получение списка дочерних групп рекурсивно в глубину
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Связанный IRequest объект группы доступа
        /// </summary>
        ICustomObject Object { get; }
        /// <summary>
        /// Члены группы
        /// </summary>
        IUsers Users { get; }
        /// <summary>
        /// Список членов группы рекурсивно в глубину
        /// </summary>
        IUsers UsersRecurcive { get; }
        /// <summary>
        /// Добавить дочернюю группу
        /// </summary>
        /// <param name="group">IGroup добавляемая группа</param>
        void AddGroup(IGroup group);
        /// <summary>
        /// Добавление нового члена группы
        /// </summary>
        /// <param name="user">IUser член группы</param>
        void AddUser(IUser user);
        /// <summary>
        /// Проверка нахождения группы в дочерних группах
        /// </summary>
        /// <param name="groupName">Название проверяемой группы</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Проверка нахождения группы в дочерних группах рекурсивно в глубину
        /// </summary>
        /// <param name="groupName">Название проверяемой группы</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Удаление группы из списка дочерних групп
        /// </summary>
        /// <param name="group">Удаляемая группа</param>
        void RemoveGroup(IGroup group);
        /// <summary>
        /// Удаление пользователя из списка членов группы
        /// </summary>
        /// <param name="user">IUser удаляемый пользователь</param>
        void RemoveUser(IUser user);
        /// <summary>
        /// Удалить объект
        /// </summary>
        void Delete();
        /// <summary>
        /// Сохранить изменения в объекте
        /// </summary>
        void Save();
        /// <summary>
        /// Отправить e-mail сообщение на указанный адрес
        /// <seealso cref="EmailAddress"/> 
        /// </summary>
        void SendEmail();
    }
}