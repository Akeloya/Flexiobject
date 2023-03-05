using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Пользователь приложения
    /// </summary>
    public interface IUser : IBase
    {
        /// <summary>
        /// Флаг состояния объекта. Активный - используется для входа в приложение, нет - не используется
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// Папка по умолчанию. Используется вместе с <see cref="HasDefaultCustomObjectFolder"/> и указывает папку, по умолчанию при открытии приложения для пользователя
        /// </summary>
        ICustomFolder DefaultRequestFolder { get; set; }
        /// <summary>
        /// Подразделение пользователя
        /// </summary>
        string Department { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        string DisplayName { get; set; }
        /// <summary>
        /// Имя домена
        /// </summary>
        string DomainName { get; set; }
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// Коллекция групп, в которую непосредственно включен пользователь
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Все группы пользователя, включая вложенные
        /// </summary>
        IGroups GroupsRecursive { get; }
        /// <summary>
        /// Имеется ли у пользователя папка по умолчанию.
        /// <see cref="DefaultRequestFolder"/>
        /// </summary>
        bool HasDefaultCustomObjectFolder { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        string LoginName { get; set; }
        /// <summary>
        /// Способ входа
        /// </summary>
        FlexiUserAuthTypes LoginMode{get;set; }
        /// <summary>
        /// Название объекта
        /// </summary>
        string Name { get; }
        /// <summary>
        /// IRequest связанный объект текущего объекта IUser
        /// </summary>
        ICustomObject Object { get; }
        /// <summary>
        /// Аккаунт эл. почты для исходящих сообщений
        /// </summary>
        string OutgoingEmailAccount { get; set; }
        /// <summary>
        /// Пароль в зашифрованном виде
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Телефон пользователя
        /// </summary>
        string Phone { get; set; }
        /// <summary>
        /// Флаг привелегий администратора
        /// </summary>
        bool Administrator { get; set; }
        /// <summary>
        /// Уникальный ИД пользователя
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Способ входа в систему.
        /// </summary>
        FlexiUserAuthenticationTypes AuthenticationType { get; set; }
        /// <summary>
        /// Добавить пользователя в группу
        /// </summary>
        /// <param name="group">Группа, в которую добавляется пользователь</param>
        void AddToGroup(IGroup group);
        /// <summary>
        /// Проверка принадлежности пользователя к группе
        /// </summary>
        /// <param name="groupName">Имя группы для проверки принадлежности</param>
        /// <returns></returns>
        bool IsInGroup(string groupName);
        /// <summary>
        /// Рекурсивная проверка принадлежности пользователя к группе
        /// </summary>
        /// <param name="groupName">Имя группы для проверки принадлежности</param>
        /// <returns></returns>
        bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Сохранить изменения объекта
        /// </summary>
        void Save();
        /// <summary>
        /// Удалить пользователя из базы данных
        /// </summary>
        void Delete();
    }
}