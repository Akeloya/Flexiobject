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
using CoaApp.Core.Enumes;

using DbProvider.Entities;

using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using System;
using System.Data.Common;

namespace DbProvider
{
    public partial class AppDbContext : DbContext
    {
        private readonly AppDbSettings _settings;
        private DbConnection _connection;
        public AppDbContext(AppDbSettings settings) : base()
        {
            _settings = settings;
        }

        public AppDbContext(DbConnection connection): base()
        {
            _connection = connection;
        }
        
        public virtual DbSet<ModifyAction> Actions { get; set; }
        public virtual DbSet<AppFolderField> AppFolderFields { get; set; }
        public virtual DbSet<AppFolder> AppFolders { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppUsersUserGroups> AppUsersUserGroups { get; set; }
        public virtual DbSet<AppearView> AppearView { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<ConditionParam> ConditionParams { get; set; }
        public virtual DbSet<ConditionStps> ConditionStps { get; set; }
        public virtual DbSet<ConditionValueFields> ConditionValueFlds { get; set; }
        public virtual DbSet<DefaultValue> DefaultValues { get; set; }
        public virtual DbSet<DeletionLog> DeletionLog { get; set; }
        public virtual DbSet<FieldDefinition> FieldDefinition { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<FormCondition> FormCondition { get; set; }
        public virtual DbSet<FormProperty> FormProperty { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<ImportColMapping> ImportColMappStps { get; set; }
        public virtual DbSet<ImportColMapping> ImportColMapping { get; set; }
        public virtual DbSet<ImportFldDestFld> ImportFldDestFld { get; set; }
        public virtual DbSet<ImportFldIdFields> ImportFldIdFields { get; set; }
        public virtual DbSet<ImportFolderSettgs> ImportFolderSettgs { get; set; }
        public virtual DbSet<ImportSettings> ImportSettings { get; set; }
        public virtual DbSet<ListProperty> ListProperties { get; set; }
        public virtual DbSet<Numbering> Numbering { get; set; }
        public virtual DbSet<ObjectDef> ObjectReport { get; set; }
        public virtual DbSet<ObjectFolder> ObjectFolders { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<SchemaFieldDefinition> AppFieldDefinitions { get; set; }
        public virtual DbSet<SchemeTableDefinition> AppTableDefinitions { get; set; }
        public virtual DbSet<SchemaHistory> SchemaHistory { get; set; }
        public virtual DbSet<ScriptHistory> ScriptHistory { get; set; }
        public virtual DbSet<Script> Scripts { get; set; }
        public virtual DbSet<WfState> WfStates { get; set; }
        public virtual DbSet<WfStateTransition> WfStateTransitions { get; set; }
        public virtual DbSet<SummaryAddFields> SummaryAddFields { get; set; }
        public virtual DbSet<SummaryAddFieldsStps> SummaryAddFieldsStps { get; set; }
        public virtual DbSet<SummaryDefinition> SummaryDefinition { get; set; }
        public virtual DbSet<SummaryFieldSteps> SummaryFieldSteps { get; set; }
        public virtual DbSet<SummaryResultFields> SummaryResultFields { get; set; }
        public virtual DbSet<SynchRefFields> SynchRefFields { get; set; }
        public virtual DbSet<UserFieldProp> UserFieldProp { get; set; }
        public virtual DbSet<ViewLayoutTmp> ViewLayoutTmp { get; set; }
        public virtual DbSet<WindowLayout> WindowLayout { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connection != null)
            {
                InitiateDbConnection(optionsBuilder);
                return;
            }
            switch (_settings.DbType)
            {
                case DbTypes.MsSqlServer:
                    MsSqlInitiate(optionsBuilder);
                    break;
                case DbTypes.PostgreSql:
                    optionsBuilder.UseNpgsql($"");
                    break;        
                case DbTypes.Oracle:
                    break;
                case DbTypes.SqlLight:
                        SqlLigntBuidlString(optionsBuilder);
                    break;
                default:
                    optionsBuilder.UseSqlite("Filename=:memory:");
                    //optionsBuilder.UseInMemoryDatabase("AppDbTest");
                    break;
            }
        }

        private void SqlLigntBuidlString(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqliteConnectionStringBuilder
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = _settings.UserPassword,
                DataSource = _settings.ServerName,
            };
            optionsBuilder.UseSqlite(builder.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModifyActionInitiate(modelBuilder);
            AppFolderFieldInitiate(modelBuilder);
            AppFolderInitiate(modelBuilder);
            AppUserInitiate(modelBuilder);
            AppUsersUserGroupsInitiate(modelBuilder);
            ConditionInitiate(modelBuilder);
            ConditionParamInitiate(modelBuilder);
            ConditionValueFieldsInitiate(modelBuilder);
            DefaultValueInitiate(modelBuilder);
            DeletionLogInitiate(modelBuilder);
            FieldDefinitionInitiate(modelBuilder);
            FormInitiate(modelBuilder);
            FormConditionInitiate(modelBuilder);
            FormPropertyInitiate(modelBuilder);
            HistoryInitiate(modelBuilder);
            ImportCmStepsInitiate(modelBuilder);
            ImportColMappingInitiate(modelBuilder);
            ImportFldDestFldInitiate(modelBuilder);
            ImportFldIdFieldsInitiate(modelBuilder);
            ImportFolderSettgsInitiate(modelBuilder);
            ImportSettingsInitiate(modelBuilder);
            ListPropertyInitiate(modelBuilder);
            NumberingInitiate(modelBuilder);
            ObjectDefInitiate(modelBuilder);
            ObjectFolderInitiate(modelBuilder);
            PictureInitiate(modelBuilder);
            PrivilegeInitiate(modelBuilder);
            SchemaFieldDefinitionInitiate(modelBuilder);
            SchemeTableDefinitionInitiate(modelBuilder);
            SchemaHistoryInitiate(modelBuilder);
            ScriptHistoryInitiate(modelBuilder);
            ScriptInitiate(modelBuilder);
            WfStateInitiate(modelBuilder);
            WfStateTransitionInitiate(modelBuilder);
            SummaryAddFieldsInitiate(modelBuilder);
            SummaryAddFieldsStpsInitiate(modelBuilder);
            SummaryDefinitionInitiate(modelBuilder);
            SummaryFieldStepsInitiate(modelBuilder);
            SummaryResultFieldsInitiate(modelBuilder);
            SynchRefFieldsInitiate(modelBuilder);
            ViewLayoutTmpInitiate(modelBuilder);
            WindowLayoutInitiate(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        private static void SummaryFieldStepsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryFieldSteps>(entity =>
            {
                entity.HasOne(d => d.SummaryDef)
                    .WithMany(p => p.SummaryFieldSteps)
                    .HasForeignKey(d => d.SummaryDefId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SummaryFieldSteps_ToSummaryDefinition");
            });
        }

        private static void SummaryDefinitionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryDefinition>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.SummaryDefinition)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_SummaryDefinition_ToObjectFolders");
            });
        }

        private static void SummaryAddFieldsStpsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryAddFieldsStps>(entity =>
            {
                entity.HasOne(d => d.AddField)
                    .WithMany(p => p.SummaryAddFieldsStps)
                    .HasForeignKey(d => d.AddFieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SummaryAddFieldsStps_SummaryAddFields");
            });
        }

        private static void SummaryAddFieldsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryAddFields>(entity =>
            {
                entity.HasOne(d => d.SummaryDef)
                    .WithMany(p => p.SummaryAddFields)
                    .HasForeignKey(d => d.SummaryDefId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SummaryAddFields_ToSummaryDefinition");
            });
        }

        private static void WfStateInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WfState>(entity =>
            {
                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Status)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Status_ToFieldDefinition");
            });
        }

        private static void ScriptInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Script>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(254);

                entity.Property(e => e.NumParams).HasColumnName("Num_params");
            });
        }

        private static void ScriptHistoryInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScriptHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("smalldatetime");

                entity.Property(e => e.Modified).HasColumnType("smalldatetime");

                entity.Property(e => e.Published).HasColumnType("smalldatetime");
            });
        }

        private static void SchemeTableDefinitionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchemeTableDefinition>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("tableName")
                    .HasMaxLength(50);
            });
        }

        private static void PrivilegeInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }

        private static void ImportFldIdFieldsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportFldIdFields>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FldSettingsId).HasColumnName("fld_settings_id");

                entity.Property(e => e.FieldId).HasColumnName("ufd");
            });
        }

        private static void ImportFldDestFldInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportFldDestFld>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DestFolderId).HasColumnName("dest_folder");

                entity.Property(e => e.FldSettingsId).HasColumnName("fld_settings_id");
            });
        }

        private static void ImportCmStepsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportCmSteps>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColMappingId).HasColumnName("col_mapping_id");

                entity.Property(e => e.FieldId).HasColumnName("userfield");
            });
        }

        private static void HistoryInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.HasIndex(e => e.ObjectId);

                entity.HasIndex(e => new { e.ObjectId, e.UserField, e.State });

                entity.Property(e => e.ChangeDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NewValue).HasMaxLength(256);

                entity.Property(e => e.OldValue).HasMaxLength(256);
            });
        }

        private static void FormConditionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormCondition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(130)
                    .IsFixedLength();
            });
        }

        private static void FormInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }

        private static void ConditionValueFieldsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConditionValueFields>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }

        private static void ConditionParamInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConditionParam>(entity =>
            {
                entity.Property(e => e.StrValue)
                    .HasMaxLength(120)
                    .IsFixedLength();
            });
        }

        private static void ConditionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ParamName)
                    .HasMaxLength(40)
                    .IsFixedLength();
            });
        }

        private static void AppFolderFieldInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppFolderField>(entity =>
            {
                entity.Property(e => e.AppField).HasColumnName("AppField_id");

                entity.Property(e => e.FolderFieldId).HasColumnName("FolderField_Id");
            });
        }

        private static void AppFolderInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppFolder>(entity =>
            {
                entity.Property(e => e.AppFolderId).HasColumnName("AppFolder_Id");

                entity.Property(e => e.FolderId).HasColumnName("Folder_Id");
            });
        }

        private static void AppUsersUserGroupsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUsersUserGroups>(entity =>
            {
                entity.ToTable("AppUsers_UserGroups");

                entity.Property(e => e.UserGroupId).HasColumnName("User_Group");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });
        }

        private static void WfStateTransitionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WfStateTransition>(entity =>
            {
                entity.HasOne(d => d.Field)
                    .WithMany(p => p.StateTransitions)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StateTransitions_ToStatus");
                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.WfStateTransitions)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_StateTransitions_ObjectFolder");
            });
        }

        private static void ImportColMappingInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportColMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttachmentOption).HasColumnName("attachment_option");

                entity.Property(e => e.Dest).HasColumnName("dest");

                entity.Property(e => e.Flags).HasColumnName("flags");

                entity.Property(e => e.SettingsId).HasColumnName("settings_id");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(80)
                    .IsFixedLength();
            });
        }

        private static void DeletionLogInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeletionLog>(entity =>
            {
                entity.HasIndex(e => e.DeletedTime);

                entity.HasIndex(e => e.FolderId);

                entity.HasIndex(e => e.ObjectId);

                entity.Property(e => e.DeletedBy)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DeletedTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }

        private static void DefaultValueInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FolderId).HasColumnName("folder");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UserFieldId).HasColumnName("userfield");

                entity.Property(e => e.ValBigint).HasColumnName("val_bigint");

                entity.Property(e => e.ValStr).HasColumnName("val_str");
            });
        }

        private static void AppUserInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Department).HasMaxLength(254);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.DomainName).HasMaxLength(254);

                entity.Property(e => e.Email).HasMaxLength(254);

                entity.Property(e => e.LoginName).HasMaxLength(254);

                entity.Property(e => e.ObjectId).HasColumnName("Object_Id");

                entity.Property(e => e.Password)
                    .HasMaxLength(254)
                    .IsFixedLength();

                entity.Property(e => e.Phone).HasMaxLength(254);

            });
        }

        private static void ModifyActionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModifyAction>(entity =>
            {
                entity.HasIndex(e => new { e.ActionType, e.FolderId });

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Expression).IsRequired();

                entity.Property(e => e.Script).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("Title")
                    .HasMaxLength(200);
            });
        }

        private static void FieldDefinitionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldDefinition>(entity =>
            {
                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DataProperty).HasColumnName("Data_property");

                entity.Property(e => e.IndexDb).HasColumnName("indexDb");

                entity.Property(e => e.MaxSize).HasColumnName("max_size");

                entity.Property(e => e.MinSize).HasColumnName("min_size");

                entity.Property(e => e.RestrictionMutch)
                    .HasColumnName("match_expr")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QuicksearchField).HasColumnName("quicksearch_field");

                entity.Property(e => e.Restriction).HasColumnName("restriction");

                entity.Property(e => e.RestrictionErrMsg)
                    .HasColumnName("restrictionErrMsg")
                    .HasMaxLength(256);

                entity.Property(e => e.RestrictionScript).HasColumnName("restrictionScript");

                entity.Property(e => e.RestrictionScriptId).HasColumnName("restrictionScriptId");

                entity.Property(e => e.IsSyncronized).HasColumnName("syncronized");

                entity.Property(e => e.Type).HasConversion(c => (byte)c, c => (CoaFieldTypes)c);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.FieldDefinitions)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FieldDefinition_ToObjectFolders");
            });
        }

        private static void ImportFolderSettgsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportFolderSettgs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BulkSize).HasColumnName("bulk_size");

                entity.Property(e => e.CacheAllObjects).HasColumnName("cache_all_objects");

                entity.Property(e => e.CompatibilityFlag).HasColumnName("compatibility_flag");

                entity.Property(e => e.FieldId).HasColumnName("field");

                entity.Property(e => e.IdFieldsNull).HasColumnName("id_fields_null");

                entity.Property(e => e.IgnoreBasefilter).HasColumnName("ignore_basefilter");

                entity.Property(e => e.ImportType).HasColumnName("import_type");

                entity.Property(e => e.IncludeSubfolders).HasColumnName("include_subfolders");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.PerformanceFlags).HasColumnName("performance_flags");

                entity.Property(e => e.SettingId).HasColumnName("setting_id");

                entity.Property(e => e.UseCreationRule).HasColumnName("use_creation_rule");
            });
        }

        private static void ImportSettingsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportSettings>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DataSourceType).HasColumnName("data_source_type");
                entity.Property(e => e.DatabaseName).IsRequired().HasColumnName("database_name");
                entity.Property(e => e.Flags).HasColumnName("flags");
                entity.Property(e => e.IdColumns).HasColumnName("id_columns");
                entity.Property(e => e.Key).HasColumnName("key");
                entity.Property(e => e.LogErrors).HasColumnName("log_errors");
                entity.Property(e => e.LogfilePrefix).HasColumnName("logfile_prefix")
                    .HasMaxLength(80).IsFixedLength();

                entity.Property(e => e.Logpath).HasColumnName("logpath")
                    .HasMaxLength(250).IsFixedLength();

                entity.Property(e => e.Name).IsRequired().HasColumnName("name")
                    .HasMaxLength(80).IsFixedLength();

                entity.Property(e => e.ReflistFull).HasColumnName("reflist_full");
                entity.Property(e => e.RemoveRefs).HasColumnName("remove_refs");
                entity.Property(e => e.SqlStatement).IsRequired().HasColumnName("sql_statement");
                entity.Property(e => e.UseSql).HasColumnName("use_sql");
                entity.Property(e => e.User).HasColumnName("user_");
            });
        }

        private static void ListPropertyInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListProperty>(entity =>
            {
                entity.HasIndex(e => new { e.FolderId, e.FieldId });

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.ListProperties)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ListProperties_ToFieldDefinition");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.ListProperties)
                    .HasForeignKey(d => d.FolderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ListProperties_ToObjectFolders");
            });
        }

        private static void NumberingInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Numbering>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FolderId).HasColumnName("folder");

                entity.Property(e => e.FieldWidth).HasColumnName("field_width");

                entity.Property(e => e.FillWithZeros).HasColumnName("fill_zeroes");

                entity.Property(e => e.MinimumValue)
                    .IsRequired()
                    .HasColumnName("minimum_value")
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .HasMaxLength(20);

                entity.Property(e => e.ShareNumbers).HasColumnName("share_numbers");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .HasMaxLength(20);

                entity.Property(e => e.FieldId).HasColumnName("userField");
            });
        }

        private static void ObjectDefInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectDef>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FolderId).HasColumnName("folder");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.UserDeletedById).HasColumnName("deleted_by_user");

            });
        }

        private static void PictureInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IsIcon).HasColumnName("is_icon");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40);
            });
        }

        private static void ObjectFolderInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectFolder>(entity =>
            {
                entity.HasIndex(e => e.Alias);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.InheritNs).HasColumnName("inherit_ns");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NamingScheme)
                    .HasColumnName("name_scheme")
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("parent");

                entity.Property(e => e.OpenPictureId).HasColumnName("picture_close");

                entity.Property(e => e.ClosePictureId).HasColumnName("picture_open");

                entity.Property(e => e.WfHistoryFieldId).HasColumnName("wfHistory_fld");

            });
        }

        private static void SchemaFieldDefinitionInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchemaFieldDefinition>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataType).HasColumnName("data_type");

                entity.Property(e => e.FieldPosition).HasColumnName("field_pos");

                entity.Property(e => e.FieldSize).HasColumnName("field_size");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("fieldname")
                    .HasMaxLength(20);

                entity.Property(e => e.HasIndex).HasColumnName("has_index");

                entity.Property(e => e.SchemaDefId).HasColumnName("tab_id");
            });
        }

        private static void SchemaHistoryInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchemaHistory>(entity =>
            {
                entity.Property(e => e.DeletedArea).HasColumnName("Deleted_Area");

                entity.Property(e => e.DeletedReference).HasColumnName("Deleted_Reference");

                entity.Property(e => e.EventDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FolderId).HasColumnName("Folder_Id");

                entity.Property(e => e.FolderName)
                    .HasColumnName("Folder_Name")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.IpAddress)
                    .HasColumnName("Ip_Address")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.NewName).HasColumnName("New_Name");

                entity.Property(e => e.OldName).HasColumnName("Old_Name");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Username)
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });
        }

        private static void SummaryResultFieldsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryResultFields>(entity =>
            {
                entity.HasOne(d => d.SummaryDef)
                    .WithMany(p => p.SummaryResultFields)
                    .HasForeignKey(d => d.SummaryDefId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SummaryResultFields_ToSummaryDefinition");
            });
        }

        private static void SynchRefFieldsInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SynchRefFields>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FieldId).HasColumnName("field");

                entity.Property(e => e.PartnerFieldId).HasColumnName("partner_field");

                entity.Property(e => e.SynchOption).HasColumnName("synch_option");
            });
        }

        private static void ViewLayoutTmpInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewLayoutTmp>(entity =>
            {
                entity.Property(e => e.Layout).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("User_id");
            });
        }

        private static void WindowLayoutInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WindowLayout>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Left).HasColumnName("left");

                entity.Property(e => e.Maximized).HasColumnName("maximized");

                entity.Property(e => e.PanesStream).HasColumnName("panes_stream");

                entity.Property(e => e.Top).HasColumnName("top");

                entity.Property(e => e.UserId).HasColumnName("user_");

                entity.Property(e => e.Width).HasColumnName("width");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void FormPropertyInitiate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormProperty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });
        }
        private void InitiateDbConnection(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_settings.DbType)
            {
                case DbTypes.SqlLight:
                    optionsBuilder.UseSqlite(_connection);
                    break;
                case DbTypes.MsSqlServer:
                    optionsBuilder.UseSqlServer(_connection);
                    break;
                case DbTypes.PostgreSql:
                    optionsBuilder.UseNpgsql(_connection);
                    break;     
                case DbTypes.Oracle:
                    
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase("AppDbTest");
                    break;
            }            
        }

        private void MsSqlInitiate(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = $"Data Source={_settings.ServerName};Initial catalog={_settings.DatabaseName};";
            if (string.IsNullOrEmpty(_settings.UserName) && string.IsNullOrEmpty(_settings.UserPassword))
            {
                connectionStr += "Integrated Security=TRUE;";
            }
            else
            {
                connectionStr += $"User ID={_settings.UserName};Password={_settings.UserPassword}";
            }
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}
