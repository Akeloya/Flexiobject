namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Object modification actions
    /// </summary>
    public enum FlexiActionListType
    {
        /// <summary>
        /// Actions will execute befor object will be created in database
        /// </summary>
        BeforeCreation,
        /// <summary>
        /// Actions execute after object created in database
        /// </summary>
        AfterCreation,
        /// <summary>
        /// Actions will execute before object will be modified
        /// </summary>
        BeforeModification,
        /// <summary>
        /// Actions will execute after object will be modified
        /// </summary>
        AfterModification,
        /// <summary>
        /// Actions will execute before object wiil get state deleted
        /// </summary>
        BeforeDeletion,
        /// <summary>
        /// Actions will execute after object will get state deleted
        /// </summary>
        AfterDeletion
    }
}