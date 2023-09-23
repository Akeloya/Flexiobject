using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Разрешения для группу или пользователя, связанные с папкой
    /// </summary>
    public interface IPrivilege : IBase
    {
        /// <summary>
        /// Флаг, определяющий правила применения привилегий.
        /// true - если привилегия применяется для всех пользователей. Тогда поле <see cref="User"/> будет null
        /// false - если привилегия применяется для пользователей указанных в <see cref="User"/>
        /// </summary>
        bool AllUsers { get; set; }
        /// <summary>
        /// Флаг наследована ли привелегия от родительской папки
        /// </summary>
        bool Inherited { get; }
        /// <summary>
        /// true - если привилегия использована для группы
        /// false - для пользователя
        /// </summary>
        bool IsGroup { get; }
        /// <summary>
        /// Уровень привилегии для пользователя или группы
        /// </summary>
        FlexiEnumPrivilegeLevel PrivilegeLevel { get; set; }
        /// <summary>
        /// Пользователь или группа, для которого применяется привилегия.
        /// Возвращается объект <see cref="IUser"/> или <see cref="IGroup"/>.
        /// Для уточнения поспользуйтесь <see cref="IsGroup"/>
        /// </summary>
        dynamic User { get; set; }
        /// <summary>
        /// Сохранение изменение разрешения
        /// </summary>
        void Save();
    }
}
