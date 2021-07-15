using CoaApp.Core.Enumes;
using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field definition for user objects
    /// </summary>
    public interface IUserFieldDefinition : IBase, IEquatable<IUserFieldDefinition>
    {
        /// <summary>
        /// Field Id
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Field alias (for multilangual interface)
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Field label
        /// </summary>
        string Label { get; set; }
        /// <summary>
        /// Field definitiona detailes
        /// </summary>
        dynamic Details { get; }
        /// <summary>
        /// Field type
        /// </summary>
        CoaFieldTypes Type { get; set; }
        /// <summary>
        /// Flag for write changes to history
        /// </summary>
        bool WriteHistory { get; set; }
        /// <summary>
        /// Default value. Settings for calculating default value stores in detailes
        /// <seealso cref="Details"/>
        /// </summary>
        object DefaultValue { get; set; }
        /// <summary>
        /// Calculating
        /// </summary>
        /// <param name="oldObj">Копия объекта до изменения</param>
        /// <param name="newObj">Копия объекта после изменения</param>
        /// <returns>истина/ложь</returns>
        bool IsRequired(ICustomObject oldObj, ICustomObject newObj);
        /// <summary>
        /// Flag indicates enabled field for editing
        /// </summary>
        /// <param name="oldObj">Old copy of object</param>
        /// <param name="newObj">New copy of object</param>
        /// <returns></returns>
        bool IsEnabled(ICustomObject oldObj, ICustomObject newObj);
        /// <summary>
        /// Is it possible to change the field type
        /// </summary>
        bool CanEditFieldType(CoaFieldTypes newType);
        /// <summary>
        /// Use rule required field value
        /// </summary>
        bool UseRuleRequired { get; set; }
        /// <summary>
        /// Use rule enabled field edit
        /// </summary>
        bool UseRuleEnabled { get; set; }
        /// <summary>
        /// Required value rule
        /// </summary>
        IRule RequiredRule { get; set; }
        /// <summary>
        /// Enabled for editing field value
        /// </summary>
        IRule EnabledRule { get; set; }
        /// <summary>
        /// Index for field in database
        /// </summary>
        bool IndexFieldDb { get; set; }
        /// <summary>
        /// Index for field in server memory
        /// </summary>
        bool IndexField { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}