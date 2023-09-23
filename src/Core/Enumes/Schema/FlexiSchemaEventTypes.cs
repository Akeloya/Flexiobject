namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Event type colection modification of folder object
    /// </summary>
    public enum FlexiSchemaEventTypes : int
    {
        Folder = 1,
        Script,
        Autocalculation,
        FieldDefinitions,
        Permission,
        ActionList,
        Form,
        FormCondition,
        AppFolderMappings,
        DropDownValue,
        State,
        StateTransition,
        Picture,
        AppUser,
        AppGroup,
        DefaultValue,
        EnabledRule,
        RequiredRule,
        RestrictionRule,
        /// <summary>
        /// Server version change
        /// </summary>
        ServerVersion = 2147483647
    }
}