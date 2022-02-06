namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Object modification history action types
    /// </summary>
    public enum CoaHistoryActionTypes
    {
        /// <summary>
        /// Object created record type
        /// </summary>
        ObjCreated = 1,
        /// <summary>
        /// Object deleted record type
        /// </summary>
        ObjDeleted,
        /// <summary>
        /// Object was restored from trashbin
        /// </summary>
        ObjRestored,
        /// <summary>
        /// Object was copied
        /// </summary>
        ObjCopied,
        /// <summary>
        /// Object field was modificated
        /// </summary>
        FieldModified,
        /// <summary>
        /// Object list was modified
        /// </summary>
        ModifyObjectList,
        /// <summary>
        /// Attachment was moved
        /// </summary>
        AttachmentMoved,
        /// <summary>
        /// Reference to another object was added
        /// </summary>
        ReferenceAdded,
        /// <summary>
        /// Reference to another object was removed (field value cleared)
        /// </summary>
        ReferenceRemoved,
        /// <summary>
        /// Attachment was added
        /// </summary>
        AttachmentAdded,
        /// <summary>
        /// Attachment was deleted
        /// </summary>
        AttachmentDeleted,
        /// <summary>
        /// Attachment was modified
        /// </summary>
        AttachmentModified,
        /// <summary>
        /// Attachment description was modified
        /// </summary>
        AttachmentDescriptionModified,
        /// <summary>
        /// Schema import was created
        /// </summary>
        CreatedSchemaImport
    }
}