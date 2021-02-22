/*
*  "Custom object application core"
*  An application that implements the ability to customize object templates and actions on them.
*  Copyright (C) 2019 by Maxim V. Yugov.
*
*  This file is part of "Custom object application".
*
*  This program is free software: you can redistribute it and/or modify
*  it under the terms of the GNU General Public License as published by
*  the Free Software Foundation, either version 3 of the License, or
*  (at your option) any later version.
*
*  This program is distributed in the hope that it will be useful,
*  but WITHOUT ANY WARRANTY; without even the implied warranty of
*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
*  GNU General Public License for more details.
*
*  You should have received a copy of the GNU General Public License
*  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CoaApp.Core.Errors
{
        /// <summary>
        /// Сериализуемое исключение
        /// </summary>
        [Serializable]
        public abstract class AppException : Exception
        {
            /// <summary>
            /// Статус приложения
            /// </summary>
            public AppExceptionStatus Status { get; } = AppExceptionStatus.Terminate;
            /// <summary>
            /// Версия клиента
            /// </summary>
            public string ClientVersion { get; } = CoaInvironment.ClientVersion;
            /// <summary>
            /// Версия сервера
            /// </summary>
            public string ServerVersion { get; } = CoaInvironment.ServerVersion;
            /// <summary>
            /// Время, когда случилось исключение
            /// </summary>
            public DateTime Occured { get; } = DateTime.Now;
            /// <summary>
            /// Инициализация нового исключения
            /// </summary>
            public AppException()
            {
            }
            /// <summary>
            /// Конструктор нового исключения с сообщением
            /// </summary>
            /// <param name="message">Сообщение об ошибке</param>
            public AppException(string message) : base(message)
            {
            }
            /// <summary>
            /// Конструктор нового исключения с сообщением и вложенным исключением
            /// </summary>
            /// <param name="message">Текст исключения</param>
            /// <param name="innerException">Вложенное исключение</param>
            public AppException(string message, Exception innerException) : base(message, innerException)
            {
            }
            /// <summary>
            /// Инициализация нового исключения
            /// </summary>
            /// <param name="message">Сообщение, описывающее исключнеие</param>
            /// <param name="status">Статус сессии</param>
            public AppException(string message, AppExceptionStatus status) : base(message)
            {
                Status = status;
            }
            /// <summary>
            /// Инициализация нового исключения
            /// </summary>
            /// <param name="message">Сообщение, описывающее исключение</param>
            /// <param name="inner">Вложенное исключение</param>
            /// <param name="status">Статус сессии</param>
            public AppException(string message, Exception inner, AppExceptionStatus status) : base(message, inner)
            {
                Status = status;
            }

            /// <summary>
            /// Get data for deserialization exception
            /// </summary>
            /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
            /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
            [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
            protected AppException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                Occured = info.GetDateTime(nameof(Occured));
                Status = (AppExceptionStatus)info.GetValue(nameof(Status), typeof(AppExceptionStatus));
                string serverVersion = info.GetString(nameof(ServerVersion));
                if (!string.IsNullOrEmpty(serverVersion))
                    ServerVersion = serverVersion;
                string clientVersion = info.GetString(nameof(ClientVersion));
                if (!string.IsNullOrEmpty(clientVersion))
                    ClientVersion = clientVersion;
            }
            /// <summary>
            /// Override GetObjectData to store additional information in exception
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue(nameof(Status), Status);
                info.AddValue(nameof(Occured), Occured);
                info.AddValue(nameof(ClientVersion), ClientVersion);
                info.AddValue(nameof(ServerVersion), ServerVersion);
            }
        }
        /// <summary>
        /// Статусы исключений, определяющие можно ли продолжать работу или нет
        /// </summary>
        public enum AppExceptionStatus
        {
            /// <summary>
            /// Завершение работы
            /// </summary>
            Terminate = 1,
            /// <summary>
            /// Работа далее возможна
            /// </summary>
            Work = 2
        }
    }
