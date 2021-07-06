/*
 *  "Custom object application core"
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
using AppServer.Properties;
using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;
using DbProvider;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Services.CommandInterface
{
    [Command("db", Description = "Get info about app database")]
    public class DatabaseInfo : ICommand
    {
        private IConfiguration _config;
        public DatabaseInfo(IConfiguration config)
        {
            _config = config;
        }
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (_config == null)
                throw new CommandException(Resources.CmdStrConfigNotInitialized);
            var appConfig = new AppConfig();
            _config.GetSection(AppConfig.ConfigName).Bind(appConfig);

            console.Output.WriteLine(string.Format(Resources.CmdStrDbType, appConfig.Database.Type));
            console.Output.WriteLine(string.Format(Resources.CmdStrServerName, appConfig.Database.Server));
            console.Output.WriteLine(string.Format(Resources.CmdStrDbName, appConfig.Database.DbName));
            console.Output.WriteLine(string.Format(Resources.CmdStrDbSecurity, appConfig.Database.Security));
            if(appConfig.Database.Security == "Password")
            {
                console.Output.WriteLine(string.Format(Resources.CmdStrDbLogin, appConfig.Database.UserName));
                console.Output.WriteLine(string.Format(Resources.CmdStrDbPassword, appConfig.Database.Password));
            }
            
            return default;
        }
    }

    [Command("db set", Description = "Set connection data to database")]
    public class DatabaseSetConfig : ICommand
    {
        [CommandOption('d', Description = "Server name")]
        public string ServerName { get; set; }
        [CommandOption('c', Description = "Database name")]
        public string DatabaseName { get; set; }
        [CommandOption('l', Description = "User login")]
        public string Login { get; set; }
        [CommandOption('p', Description = "User password")]
        public string Password { get; set; }
        public ValueTask ExecuteAsync(IConsole console)
        {
            throw new NotImplementedException();
        }
    }

    [Command("db clear", Description = "Clear schema or data in database")]
    public class DatabaseClear : ICommand
    {
        private readonly IConfiguration _config;
        public DatabaseClear(IConfiguration config)
        {
            _config = config;
        }
        [CommandOption('f', Description = "Clear mode")]
        public ClearFlags Flags { get; set; }
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (_config == null)
                throw new CommandException(Resources.CmdStrConfigNotInitialized);
            var appConfig = new AppConfig();
            _config.GetSection(AppConfig.ConfigName).Bind(appConfig);

            return default;
        }
    }

    [Command("db init", Description = "Initialize empty database")]
    public class DatabaseInit : ICommand
    {
        private readonly IConfiguration _config;
        public DatabaseInit(IConfiguration config)
        {
            _config = config;
        }
        [CommandParameter(0, Name = "Type", Description = "Database type")]
        public DbTypes Type { get; set; }
        [CommandParameter(1, Name = "ServerName", Description = "Server name")]
        public string ServerName { get; set; }
        [CommandParameter(2, Name = "DatabaseName", Description = "Database name")]
        public string DatabaseName { get; set; }
        [CommandOption('l', Description = "User login")]
        public string Login { get; set; }
        [CommandOption('p', Description = "User password")]
        public string Password { get; set; }
        [CommandOption('s', Description = "Save connection")]
        public bool SaveConnection { get; set; }
        [CommandOption('u', Description = "Use existing connection")]
        public bool UseSavedConnection { get; set; }
        [CommandOption('o', Description = "Overwrite if database exists")]
        public bool Overwrite { get; set; }
        public ValueTask ExecuteAsync(IConsole console)
        {
            IAppDbSettings dbSettings;
            if (UseSavedConnection)
            {
                if (_config == null)
                    throw new CommandException(Resources.CmdStrConfigNotInitialized);
                var appConfig = new AppConfig();
                _config.GetSection(AppConfig.ConfigName).Bind(appConfig);
                dbSettings = appConfig.Database;
            }
            else
            {
                dbSettings = new DatabaseConfig
                {
                    DbName = DatabaseName,
                    Type = Type,
                    UserName = Login,
                    Password = Password,
                    Server = ServerName
                };
            }
            var dbContext = new AppDbContext(dbSettings);
            if (Overwrite)
                dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            if(SaveConnection)
            {
                _config.GetSection(AppConfig.ConfigName).Bind(dbSettings);
            }
            return default;
        }
    }

    [Command("db check", Description = "Check schema in database")]
    public class DatabaseCheck : ICommand
    {
        private readonly IConfiguration _config;
        public DatabaseCheck(IConfiguration config)
        {
            _config = config;
        }
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (_config == null)
                throw new CommandException(Resources.CmdStrConfigNotInitialized);
            var appConfig = new AppConfig();
            _config.GetSection(AppConfig.ConfigName).Bind(appConfig);

            SqlManager.RegisterManager(appConfig.Database);
            var result = false;
            try
            {
                using ISqlConnectionItem connection = SqlManager.Register(Guid.NewGuid());
                connection.Context.ObjectFolders.Any();
                connection.Close();
                result = true;
            }
            catch
            {
                result = false;
            }

            if (result)
                console.Output.WriteLine("Check success!");
            else
                console.Output.WriteLine("Check fails!");
            return default;
        }
    }

    [Flags]
    public enum ClearFlags
    {
        Data = 1,
        Full = 2
    }
}
