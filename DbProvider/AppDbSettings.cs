/*
 *  "Custom object application database provider"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
namespace DbProvider
{
    public interface IAppDbSettings
    {
        public DbTypes Type { get; set; }
        public string Server { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AppDbSettings : IAppDbSettings
    {
        public DbTypes Type { get; set; }
        public string Server { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public AppDbSettings(DbTypes type, string serverName, string dbName, string userName, string password)
        {
            Type = type;
            Server = serverName;
            DbName = dbName;
            UserName = userName;
            Password = password;
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
