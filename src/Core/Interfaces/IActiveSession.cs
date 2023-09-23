using System;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Активная (текущая) сессия пользователя
    /// </summary>
    public interface IActiveSession : IBase
    {
        /// <summary>
        /// Тип клиента
        /// </summary>
        string ClientType { get; }
        /// <summary>
        /// Хост пользователя
        /// </summary>
        string HostName { get; }
        /// <summary>
        /// Время логина
        /// </summary>
        DateTime LoginTime { get; }
        /// <summary>
        /// Время простоя (отсутствия трафика между клиентом и сервером)
        /// </summary>
        DateTime IdleTime { get; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Закрыть сессию
        /// </summary>
        void Close();
    }
}