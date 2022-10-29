/*
 *  "Flexiobject database provider"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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
namespace FlexiObject.DbProvider
{
    public struct AppDbSettings
    {
        public DbTypes DbType { get; }
        public string ServerName { get; }
        public string DatabaseName { get; }
        public string UserName { get; }
        public string UserPassword { get; }

        public AppDbSettings(DbTypes type, string serverName, string dbName, string userName, string password)
        {
            DbType = type;
            ServerName = serverName;
            DatabaseName = dbName;
            UserName = userName;
            UserPassword = password;
        }
    }

    public enum DbTypes
    {
        Files,
        Memory,
        MsJet,
        MsSqlServer,
        MySql,
        Oracle,
        PostgreSql,
        SqlLight
    }
}
