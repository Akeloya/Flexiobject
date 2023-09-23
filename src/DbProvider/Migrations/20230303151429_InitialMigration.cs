using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexiOject.DbProvider.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Rule = table.Column<int>(type: "INTEGER", nullable: false),
                    Operator = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Property = table.Column<byte>(type: "INTEGER", nullable: false),
                    KeyProperty = table.Column<int>(type: "INTEGER", nullable: false),
                    Comparison = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 40, nullable: true),
                    MatchAll = table.Column<bool>(type: "INTEGER", nullable: true),
                    PropertyFlag = table.Column<byte>(type: "INTEGER", nullable: true),
                    ParamPos = table.Column<short>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Conditions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeletionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DeletedBy = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    RefType = table.Column<byte>(type: "INTEGER", nullable: false),
                    Ref = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    DataType = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportColMapping",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    settings_id = table.Column<int>(type: "INTEGER", nullable: false),
                    source = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 80, nullable: false),
                    dest = table.Column<int>(type: "INTEGER", nullable: false),
                    flags = table.Column<byte>(type: "INTEGER", nullable: false),
                    attachment_option = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportColMapping", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ImportSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    key = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 80, nullable: false),
                    database_name = table.Column<string>(type: "TEXT", nullable: false),
                    sql_statement = table.Column<string>(type: "TEXT", nullable: false),
                    user_ = table.Column<int>(type: "INTEGER", nullable: false),
                    data_source_type = table.Column<short>(type: "INTEGER", nullable: false),
                    log_errors = table.Column<bool>(type: "INTEGER", nullable: false),
                    logfile_prefix = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 80, nullable: true),
                    logpath = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 250, nullable: true),
                    use_sql = table.Column<bool>(type: "INTEGER", nullable: false),
                    flags = table.Column<short>(type: "INTEGER", nullable: false),
                    reflist_full = table.Column<bool>(type: "INTEGER", nullable: false),
                    remove_refs = table.Column<bool>(type: "INTEGER", nullable: false),
                    id_columns = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportSettings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    data = table.Column<byte[]>(type: "BLOB", nullable: true),
                    is_icon = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuleType = table.Column<byte>(type: "INTEGER", nullable: false),
                    RefId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchemeTableDef",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    tableName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeTableDef", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectFolder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    name_scheme = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    inherit_ns = table.Column<bool>(type: "INTEGER", nullable: false),
                    parent = table.Column<int>(type: "INTEGER", nullable: false),
                    picture_close = table.Column<int>(type: "INTEGER", nullable: false),
                    picture_open = table.Column<int>(type: "INTEGER", nullable: false),
                    wfHistory_fld = table.Column<int>(type: "INTEGER", nullable: true),
                    PictureOpenId = table.Column<int>(type: "INTEGER", nullable: true),
                    PictureCloseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectFolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectFolder_ObjectFolder_parent",
                        column: x => x.parent,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectFolder_Pictures_PictureCloseId",
                        column: x => x.PictureCloseId,
                        principalTable: "Pictures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ObjectFolder_Pictures_PictureOpenId",
                        column: x => x.PictureOpenId,
                        principalTable: "Pictures",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SchemeFieldsDef",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    field_pos = table.Column<short>(type: "INTEGER", nullable: false),
                    field_size = table.Column<int>(type: "INTEGER", nullable: false),
                    fieldname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    data_type = table.Column<short>(type: "INTEGER", nullable: false),
                    has_index = table.Column<bool>(type: "INTEGER", nullable: false),
                    tab_id = table.Column<int>(type: "INTEGER", nullable: false),
                    SchemeDefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeFieldsDef", x => x.id);
                    table.ForeignKey(
                        name: "FK_SchemeFieldsDef_SchemeTableDef_SchemeDefId",
                        column: x => x.SchemeDefId,
                        principalTable: "SchemeTableDef",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AppFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    AppFolder_Id = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFolders_ObjectFolder_Folder_Id",
                        column: x => x.Folder_Id,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    WriteHistory = table.Column<bool>(type: "INTEGER", nullable: false),
                    FolderReferenceId = table.Column<int>(type: "INTEGER", nullable: true),
                    Data_property = table.Column<int>(type: "INTEGER", nullable: false),
                    quicksearch_field = table.Column<int>(type: "INTEGER", nullable: false),
                    min_size = table.Column<int>(type: "INTEGER", nullable: false),
                    max_size = table.Column<int>(type: "INTEGER", nullable: false),
                    indexDb = table.Column<bool>(type: "INTEGER", nullable: false),
                    restriction = table.Column<bool>(type: "INTEGER", nullable: false),
                    restrictionScript = table.Column<bool>(type: "INTEGER", nullable: false),
                    restrictionScriptId = table.Column<int>(type: "INTEGER", nullable: false),
                    restrictionErrMsg = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    match_expr = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    syncronized = table.Column<bool>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDefinition_ToObjectFolders",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldDefinitions_ObjectFolder_FolderReferenceId",
                        column: x => x.FolderReferenceId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Form_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImportFldDestFld",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    fld_settings_id = table.Column<int>(type: "INTEGER", nullable: false),
                    dest_folder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFldDestFld", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportFldDestFld_ObjectFolder_dest_folder",
                        column: x => x.dest_folder,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModifyActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Expression = table.Column<string>(type: "TEXT", nullable: false),
                    Script = table.Column<string>(type: "TEXT", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifyActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifyActions_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectDef",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    folder = table.Column<int>(type: "INTEGER", nullable: false),
                    deleted_by_user = table.Column<int>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectDef", x => x.id);
                    table.ForeignKey(
                        name: "FK_ObjectDef_ObjectFolder_folder",
                        column: x => x.folder,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemaHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Reference = table.Column<int>(type: "INTEGER", nullable: false),
                    EventDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    User_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Folder_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Folder_Name = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 200, nullable: true),
                    Old_Name = table.Column<string>(type: "TEXT", nullable: true),
                    New_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Action = table.Column<byte>(type: "INTEGER", nullable: false),
                    Deleted_Reference = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted_Area = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 50, nullable: false),
                    Ip_Address = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 128, nullable: true),
                    ObjectFolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemaHistory_ObjectFolder_ObjectFolderId",
                        column: x => x.ObjectFolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Scripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    ScriptCode = table.Column<string>(type: "TEXT", nullable: true),
                    Ref = table.Column<int>(type: "INTEGER", nullable: true),
                    Num_params = table.Column<byte>(type: "INTEGER", nullable: true),
                    DetermFldsValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scripts_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SummaryDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    RefField = table.Column<int>(type: "INTEGER", nullable: true),
                    ScriptId = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifObjFlags = table.Column<int>(type: "INTEGER", nullable: true),
                    RecalcAfterRemove = table.Column<bool>(type: "INTEGER", nullable: true),
                    StoreZero = table.Column<bool>(type: "INTEGER", nullable: true),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryDefinition_ToObjectFolders",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppFolderFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FolderField_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    AppFolderId = table.Column<int>(type: "INTEGER", nullable: true),
                    AppField_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFolderFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFolderFields_AppFolders_AppFolderId",
                        column: x => x.AppFolderId,
                        principalTable: "AppFolders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFolderFields_FieldDefinitions_FolderField_Id",
                        column: x => x.FolderField_Id,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConditionId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserFieldId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionSteps_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionSteps_FieldDefinitions_UserFieldId",
                        column: x => x.UserFieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefaultValues",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<byte>(type: "INTEGER", nullable: false),
                    val_bigint = table.Column<long>(type: "INTEGER", nullable: true),
                    val_str = table.Column<string>(type: "TEXT", nullable: true),
                    userfield = table.Column<int>(type: "INTEGER", nullable: false),
                    folder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultValues", x => x.id);
                    table.ForeignKey(
                        name: "FK_DefaultValues_FieldDefinitions_userfield",
                        column: x => x.userfield,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefaultValues_ObjectFolder_folder",
                        column: x => x.folder,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportCmStps",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    col_mapping_id = table.Column<int>(type: "INTEGER", nullable: false),
                    userfield = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportCmStps", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportCmStps_FieldDefinitions_userfield",
                        column: x => x.userfield,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportCmStps_ImportColMapping_col_mapping_id",
                        column: x => x.col_mapping_id,
                        principalTable: "ImportColMapping",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportFldIdFields",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    fld_settings_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ufd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFldIdFields", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportFldIdFields_FieldDefinitions_ufd",
                        column: x => x.ufd,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportFolderSettgs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parent = table.Column<int>(type: "INTEGER", nullable: false),
                    import_type = table.Column<short>(type: "INTEGER", nullable: false),
                    use_creation_rule = table.Column<bool>(type: "INTEGER", nullable: false),
                    cache_all_objects = table.Column<bool>(type: "INTEGER", nullable: false),
                    include_subfolders = table.Column<bool>(type: "INTEGER", nullable: false),
                    performance_flags = table.Column<int>(type: "INTEGER", nullable: true),
                    bulk_size = table.Column<int>(type: "INTEGER", nullable: false),
                    ignore_basefilter = table.Column<bool>(type: "INTEGER", nullable: false),
                    compatibility_flag = table.Column<bool>(type: "INTEGER", nullable: false),
                    id_fields_null = table.Column<bool>(type: "INTEGER", nullable: false),
                    field = table.Column<int>(type: "INTEGER", nullable: false),
                    setting_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFolderSettgs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportFolderSettgs_FieldDefinitions_field",
                        column: x => x.field,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportFolderSettgs_ImportSettings_setting_id",
                        column: x => x.setting_id,
                        principalTable: "ImportSettings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListProperties_ToFieldDefinition",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListProperties_ToObjectFolders",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Numbering",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prefix = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    suffix = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    fill_zeroes = table.Column<bool>(type: "INTEGER", nullable: false),
                    field_width = table.Column<int>(type: "INTEGER", nullable: true),
                    minimum_value = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 16, nullable: false),
                    share_numbers = table.Column<bool>(type: "INTEGER", nullable: false),
                    folder = table.Column<int>(type: "INTEGER", nullable: false),
                    userField = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbering", x => x.id);
                    table.ForeignKey(
                        name: "FK_Numbering_FieldDefinitions_userField",
                        column: x => x.userField,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Numbering_ObjectFolder_folder",
                        column: x => x.folder,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SynchRefFields",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    synch_option = table.Column<byte>(type: "INTEGER", nullable: false),
                    field = table.Column<int>(type: "INTEGER", nullable: false),
                    partner_field = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SynchRefFields", x => x.id);
                    table.ForeignKey(
                        name: "FK_SynchRefFields_FieldDefinitions_field",
                        column: x => x.field,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SynchRefFields_FieldDefinitions_partner_field",
                        column: x => x.partner_field,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFieldProp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: true),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true),
                    Flag = table.Column<bool>(type: "INTEGER", nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    UseScript = table.Column<bool>(type: "INTEGER", nullable: false),
                    Script = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFieldProp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFieldProp_FieldDefinitions_FieldId",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFieldProp_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WfStateTransitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Old = table.Column<int>(type: "INTEGER", nullable: false),
                    New = table.Column<int>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfStateTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateTransitions_ObjectFolder",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StateTransitions_ToStatus",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Initial = table.Column<bool>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_ToFieldDefinition",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfStatus_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCondition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true),
                    Position = table.Column<short>(type: "INTEGER", nullable: false),
                    FormId = table.Column<int>(type: "INTEGER", nullable: true),
                    Object = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 130, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCondition_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormCondition_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginName = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    IsAdministrator = table.Column<bool>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 254, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    IsGroup = table.Column<bool>(type: "INTEGER", nullable: false),
                    GroupMail = table.Column<byte>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LoginMode = table.Column<int>(type: "INTEGER", nullable: false),
                    DomainName = table.Column<string>(type: "TEXT", maxLength: 254, nullable: true),
                    Object_Id = table.Column<long>(type: "INTEGER", nullable: true),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_To_ObjectDef",
                        column: x => x.Object_Id,
                        principalTable: "ObjectDef",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ConditionParams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    ConditionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Value = table.Column<byte>(type: "INTEGER", nullable: false),
                    LongValue = table.Column<long>(type: "INTEGER", nullable: false),
                    StrValue = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 120, nullable: true),
                    DoubleValue = table.Column<double>(type: "REAL", nullable: false),
                    LongValueHigh = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectType = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionParams_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionParams_ObjectDef_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "ObjectDef",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ScriptHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceScriptId = table.Column<int>(type: "INTEGER", nullable: true),
                    Script = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Published = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScriptHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScriptHistory_Scripts_SourceScriptId",
                        column: x => x.SourceScriptId,
                        principalTable: "Scripts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SummaryAddFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SummaryDefId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryAddFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryAddFields_FieldDefinitions_FieldId",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummaryAddFields_ToSummaryDefinition",
                        column: x => x.SummaryDefId,
                        principalTable: "SummaryDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SummaryFieldSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SummaryDefId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldDefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryFieldSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryFieldSteps_FieldDefinitions_FieldDefId",
                        column: x => x.FieldDefId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SummaryFieldSteps_ToSummaryDefinition",
                        column: x => x.SummaryDefId,
                        principalTable: "SummaryDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SummaryResultFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SummaryDefId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldDefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryResultFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryResultFields_FieldDefinitions_FieldDefId",
                        column: x => x.FieldDefId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SummaryResultFields_ToSummaryDefinition",
                        column: x => x.SummaryDefId,
                        principalTable: "SummaryDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppearView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppearView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppearView_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppearView_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppUsers_UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User_Id = table.Column<int>(type: "INTEGER", nullable: false),
                    User_Group = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_UserGroups_AppUsers_User_Group",
                        column: x => x.User_Group,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsers_UserGroups_AppUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChangeDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Attribute = table.Column<byte>(type: "INTEGER", nullable: false),
                    UserField = table.Column<int>(type: "INTEGER", nullable: true),
                    OldValue = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NewValue = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Format = table.Column<byte>(type: "INTEGER", nullable: false),
                    ObjectId = table.Column<long>(type: "INTEGER", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjHistory_AppUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjHistory_ToObjDef",
                        column: x => x.ObjectId,
                        principalTable: "ObjectDef",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privilege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Privilege_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Privilege_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ViewLayoutTmp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Layout = table.Column<byte[]>(type: "BLOB", nullable: false),
                    User_id = table.Column<int>(type: "INTEGER", nullable: false),
                    FolderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewLayoutTmp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewLayoutTmp_AppUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViewLayoutTmp_ObjectFolder_FolderId",
                        column: x => x.FolderId,
                        principalTable: "ObjectFolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WindowLayout",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    width = table.Column<int>(type: "INTEGER", nullable: true),
                    height = table.Column<int>(type: "INTEGER", nullable: true),
                    left = table.Column<int>(type: "INTEGER", nullable: true),
                    top = table.Column<int>(type: "INTEGER", nullable: true),
                    maximized = table.Column<bool>(type: "INTEGER", nullable: true),
                    panes_stream = table.Column<byte[]>(type: "BLOB", nullable: true),
                    user_ = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowLayout", x => x.id);
                    table.ForeignKey(
                        name: "FK_WindowLayout_AppUsers_user_",
                        column: x => x.user_,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionValueFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    CondParamsId = table.Column<int>(type: "INTEGER", nullable: true),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionValueFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionValueFields_ConditionParams_CondParamsId",
                        column: x => x.CondParamsId,
                        principalTable: "ConditionParams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionValueFields_FieldDefinitions_FieldId",
                        column: x => x.FieldId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SummaryAddFieldsStps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldDefId = table.Column<int>(type: "INTEGER", nullable: false),
                    AddFieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryAddFieldsStps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryAddFieldsStps_FieldDefinitions_FieldDefId",
                        column: x => x.FieldDefId,
                        principalTable: "FieldDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummaryAddFieldsStps_SummaryAddFields",
                        column: x => x.AddFieldId,
                        principalTable: "SummaryAddFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppearView_FolderId",
                table: "AppearView",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppearView_UserId",
                table: "AppearView",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFolderFields_AppFolderId",
                table: "AppFolderFields",
                column: "AppFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFolderFields_FolderField_Id",
                table: "AppFolderFields",
                column: "FolderField_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppFolders_Folder_Id",
                table: "AppFolders",
                column: "Folder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Object_Id",
                table: "AppUsers",
                column: "Object_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserGroups_User_Group",
                table: "AppUsers_UserGroups",
                column: "User_Group");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserGroups_User_Id",
                table: "AppUsers_UserGroups",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionParams_ConditionId",
                table: "ConditionParams",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionParams_ObjectId",
                table: "ConditionParams",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ParentId",
                table: "Conditions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionSteps_ConditionId",
                table: "ConditionSteps",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionSteps_UserFieldId",
                table: "ConditionSteps",
                column: "UserFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionValueFields_CondParamsId",
                table: "ConditionValueFields",
                column: "CondParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionValueFields_FieldId",
                table: "ConditionValueFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultValues_folder",
                table: "DefaultValues",
                column: "folder");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultValues_userfield",
                table: "DefaultValues",
                column: "userfield");

            migrationBuilder.CreateIndex(
                name: "IX_DeletionLog_DeletedTime",
                table: "DeletionLog",
                column: "DeletedTime");

            migrationBuilder.CreateIndex(
                name: "IX_DeletionLog_FolderId",
                table: "DeletionLog",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletionLog_ObjectId",
                table: "DeletionLog",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDefinitions_FolderId",
                table: "FieldDefinitions",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDefinitions_FolderReferenceId",
                table: "FieldDefinitions",
                column: "FolderReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_FolderId",
                table: "Form",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCondition_FolderId",
                table: "FormCondition",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCondition_FormId",
                table: "FormCondition",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCmStps_col_mapping_id",
                table: "ImportCmStps",
                column: "col_mapping_id");

            migrationBuilder.CreateIndex(
                name: "IX_ImportCmStps_userfield",
                table: "ImportCmStps",
                column: "userfield");

            migrationBuilder.CreateIndex(
                name: "IX_ImportFldDestFld_dest_folder",
                table: "ImportFldDestFld",
                column: "dest_folder");

            migrationBuilder.CreateIndex(
                name: "IX_ImportFldIdFields_ufd",
                table: "ImportFldIdFields",
                column: "ufd");

            migrationBuilder.CreateIndex(
                name: "IX_ImportFolderSettgs_field",
                table: "ImportFolderSettgs",
                column: "field");

            migrationBuilder.CreateIndex(
                name: "IX_ImportFolderSettgs_setting_id",
                table: "ImportFolderSettgs",
                column: "setting_id");

            migrationBuilder.CreateIndex(
                name: "IX_ListProperties_FieldId",
                table: "ListProperties",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ListProperties_FolderId_FieldId",
                table: "ListProperties",
                columns: new[] { "FolderId", "FieldId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModifyActions_ActionType_FolderId",
                table: "ModifyActions",
                columns: new[] { "ActionType", "FolderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModifyActions_FolderId",
                table: "ModifyActions",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Numbering_folder",
                table: "Numbering",
                column: "folder");

            migrationBuilder.CreateIndex(
                name: "IX_Numbering_userField",
                table: "Numbering",
                column: "userField");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDef_folder",
                table: "ObjectDef",
                column: "folder");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFolder_Alias",
                table: "ObjectFolder",
                column: "Alias");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFolder_parent",
                table: "ObjectFolder",
                column: "parent");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFolder_PictureCloseId",
                table: "ObjectFolder",
                column: "PictureCloseId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFolder_PictureOpenId",
                table: "ObjectFolder",
                column: "PictureOpenId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjHistory_ModifiedById",
                table: "ObjHistory",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjHistory_ObjectId",
                table: "ObjHistory",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjHistory_ObjectId_UserField_State",
                table: "ObjHistory",
                columns: new[] { "ObjectId", "UserField", "State" });

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_AppUserId",
                table: "Privilege",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Privilege_FolderId",
                table: "Privilege",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemaHistory_ObjectFolderId",
                table: "SchemaHistory",
                column: "ObjectFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeFieldsDef_SchemeDefId",
                table: "SchemeFieldsDef",
                column: "SchemeDefId");

            migrationBuilder.CreateIndex(
                name: "IX_ScriptHistory_SourceScriptId",
                table: "ScriptHistory",
                column: "SourceScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_FolderId",
                table: "Scripts",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAddFields_FieldId",
                table: "SummaryAddFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAddFields_SummaryDefId",
                table: "SummaryAddFields",
                column: "SummaryDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAddFieldsStps_AddFieldId",
                table: "SummaryAddFieldsStps",
                column: "AddFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAddFieldsStps_FieldDefId",
                table: "SummaryAddFieldsStps",
                column: "FieldDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryDefinition_FolderId",
                table: "SummaryDefinition",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryFieldSteps_FieldDefId",
                table: "SummaryFieldSteps",
                column: "FieldDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryFieldSteps_SummaryDefId",
                table: "SummaryFieldSteps",
                column: "SummaryDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryResultFields_FieldDefId",
                table: "SummaryResultFields",
                column: "FieldDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryResultFields_SummaryDefId",
                table: "SummaryResultFields",
                column: "SummaryDefId");

            migrationBuilder.CreateIndex(
                name: "IX_SynchRefFields_field",
                table: "SynchRefFields",
                column: "field");

            migrationBuilder.CreateIndex(
                name: "IX_SynchRefFields_partner_field",
                table: "SynchRefFields",
                column: "partner_field");

            migrationBuilder.CreateIndex(
                name: "IX_UserFieldProp_FieldId",
                table: "UserFieldProp",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFieldProp_FolderId",
                table: "UserFieldProp",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewLayoutTmp_FolderId",
                table: "ViewLayoutTmp",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewLayoutTmp_User_id",
                table: "ViewLayoutTmp",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_WfStateTransitions_FieldId",
                table: "WfStateTransitions",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WfStateTransitions_FolderId",
                table: "WfStateTransitions",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_WfStatus_FieldId",
                table: "WfStatus",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WfStatus_FolderId",
                table: "WfStatus",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_WindowLayout_user_",
                table: "WindowLayout",
                column: "user_");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppearView");

            migrationBuilder.DropTable(
                name: "AppFolderFields");

            migrationBuilder.DropTable(
                name: "AppUsers_UserGroups");

            migrationBuilder.DropTable(
                name: "ConditionSteps");

            migrationBuilder.DropTable(
                name: "ConditionValueFields");

            migrationBuilder.DropTable(
                name: "DefaultValues");

            migrationBuilder.DropTable(
                name: "DeletionLog");

            migrationBuilder.DropTable(
                name: "FormCondition");

            migrationBuilder.DropTable(
                name: "FormProperty");

            migrationBuilder.DropTable(
                name: "ImportCmStps");

            migrationBuilder.DropTable(
                name: "ImportFldDestFld");

            migrationBuilder.DropTable(
                name: "ImportFldIdFields");

            migrationBuilder.DropTable(
                name: "ImportFolderSettgs");

            migrationBuilder.DropTable(
                name: "ListProperties");

            migrationBuilder.DropTable(
                name: "ModifyActions");

            migrationBuilder.DropTable(
                name: "Numbering");

            migrationBuilder.DropTable(
                name: "ObjHistory");

            migrationBuilder.DropTable(
                name: "Privilege");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "SchemaHistory");

            migrationBuilder.DropTable(
                name: "SchemeFieldsDef");

            migrationBuilder.DropTable(
                name: "ScriptHistory");

            migrationBuilder.DropTable(
                name: "SummaryAddFieldsStps");

            migrationBuilder.DropTable(
                name: "SummaryFieldSteps");

            migrationBuilder.DropTable(
                name: "SummaryResultFields");

            migrationBuilder.DropTable(
                name: "SynchRefFields");

            migrationBuilder.DropTable(
                name: "UserFieldProp");

            migrationBuilder.DropTable(
                name: "ViewLayoutTmp");

            migrationBuilder.DropTable(
                name: "WfStateTransitions");

            migrationBuilder.DropTable(
                name: "WfStatus");

            migrationBuilder.DropTable(
                name: "WindowLayout");

            migrationBuilder.DropTable(
                name: "AppFolders");

            migrationBuilder.DropTable(
                name: "ConditionParams");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "ImportColMapping");

            migrationBuilder.DropTable(
                name: "ImportSettings");

            migrationBuilder.DropTable(
                name: "SchemeTableDef");

            migrationBuilder.DropTable(
                name: "Scripts");

            migrationBuilder.DropTable(
                name: "SummaryAddFields");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "FieldDefinitions");

            migrationBuilder.DropTable(
                name: "SummaryDefinition");

            migrationBuilder.DropTable(
                name: "ObjectDef");

            migrationBuilder.DropTable(
                name: "ObjectFolder");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
