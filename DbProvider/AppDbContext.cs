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
using DbProvider.Entities;

using EntityFrameworkCore.Jet;

using FileContextCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace DbProvider
{
    public class AppDbContext : DbContext
    {
        private readonly AppDbSettings _settings;
        public AppDbContext(AppDbSettings settings) : base()
        {
            _settings = settings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_settings.DbType)
            {
                case DbTypes.MsSqlServer:
                    optionsBuilder.UseSqlServer($"ServerName={_settings.ServerName};Data");
                    break;
                case DbTypes.PostgreSql:
                    optionsBuilder.UseNpgsql($"");
                    break;
#if Windows
                case DbTypes.MsJet:
                    optionsBuilder.UseJet($"");
                    break;
#endif                
                case DbTypes.MySql:
                    optionsBuilder.UseMySql($"");
                    break;
                case DbTypes.Oracle:
                    break;
                case DbTypes.Files:
                    optionsBuilder.UseFileContextDatabase(_settings.DatabaseName, _settings.ServerName, _settings.UserPassword);
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase("AppDbTest");
                    break;
            }
        }
        public DbSet<AppFolder> AppFolders { get; set; }
        public DbSet<AppFolderFields> AppFolderFields { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }
        public DbSet<ObjectFolder> ObjectFolder { get; set; }
        public DbSet<ObjectHistory> ObjectHistoryP { get; set; }
        public DbSet<AppFieldDefinition> AppFieldDefinitions { get; set; }
        public DbSet<WfState> WfStates { get; set; }
        public DbSet<WfStateTransition> WfStateTransitions { get; set; }
    }


}
