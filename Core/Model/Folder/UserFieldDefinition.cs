using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CoaApp.Core
{
    /// <inheritdoc/>
    public abstract class CoaUserFieldDefinition : AppBase, IUserFieldDefinition
    {
        private int _id;
        /// <summary>
        /// Base constructor for new fields
        /// </summary>
        /// <param name="app">
        /// Reference to application
        /// </param>
        /// <param name="parent">
        /// Parent object or object-creator
        /// </param>
        protected CoaUserFieldDefinition(IApplication app, object parent): base(app, parent)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="id"></param>
        protected CoaUserFieldDefinition(IApplication app, object parent, int id): base(app,parent)
        {
            _id = id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startFolder"></param>
        /// <param name="fieldPath"></param>
        /// <returns></returns>
        public static IList<IUserFieldDefinition> GetFieldsByPath(ICustomFolder startFolder, string fieldPath)
        {
#if DEBUG
            Debug.WriteLine("Folder = " + startFolder.Alias + " fieldPath = " + fieldPath);
#endif
            IUserFieldDefinition field = null;

            var fields = new List<IUserFieldDefinition>();

            var path = fieldPath.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                fields.Add(startFolder.UserFieldDefinitions[path[0]]);
                field = fields[0];
            }
            catch
            {
                return new List<IUserFieldDefinition>();
            }

            for (var i = 1; i < path.Length; i++)
            {
                var p = path[i];
                try
                {
                    var det = field.Details as IRefDetailes;
                    field = det.ReferencedFolder.UserFieldDefinitions[p];
                    fields.Add(field);
                }
                catch (Exception)
                {
                    break;
                }
            }

            return fields;
        }
        /// <summary>
        /// Get user field in the end of path from start folder
        /// </summary>
        /// <param name="startFolder">Start folder object</param>
        /// <param name="fieldPath">field path from starting folder</param>
        /// <returns></returns>
        public static IUserFieldDefinition GetFieldByPath(ICustomFolder startFolder, string fieldPath)
        {
            return GetFieldsByPath(startFolder, fieldPath).Last();
        }
        /// <inheritdoc/>
        public static string GetFieldPathByFieldIds(ICustomFolder startFolder, int[] fieldIds)
        {
            string result = null;
            IUserFieldDefinition field;
            ICustomFolder currFolder = startFolder;
            var fieldCount = fieldIds.Length;
            for (var i = 0; i < fieldCount; i++)
            {
                var fieldId = fieldIds[i];
                field = null;
                for (var j = 0; j < currFolder.UserFieldDefinitions.Count; j++)
                    if (currFolder.UserFieldDefinitions[j].Id == fieldId)
                    {
                        field = currFolder.UserFieldDefinitions[j];
                        break;
                    }
                if (field == null)
                    return null;
                if (fieldCount > 1 && i < fieldCount - 1)
                    currFolder = (field.Details as IRefDetailes).ReferencedFolder;
                result += field.Alias + ".";
            }
            if (result?.Length > 1)
                result = result[0..^1];//Substring(0, result.Length - 1)
            return result;
        }
        /// <inheritdoc/>
        public int Id => _id;
        /// <inheritdoc/>
        public string Alias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public dynamic Details => throw new NotImplementedException();
        /// <inheritdoc/>
        public CoaFieldTypes Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public bool WriteHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public object DefaultValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public bool CanEditFieldType(CoaFieldTypes newType)
        {
            switch (newType)
            {
                case CoaFieldTypes.Int:
                case CoaFieldTypes.ShortInt:
                case CoaFieldTypes.Bigint:
                    return true;
                default:
                    return false;
            }
        }
        /// <inheritdoc/>
        public bool UseRuleRequired { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public bool UseRuleEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public IRule RequiredRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public IRule EnabledRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public bool IndexFieldDb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public bool IndexField { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <inheritdoc/>
        public abstract bool IsEnabled(ICustomObject oldReq, ICustomObject newReq);
        /// <inheritdoc/>
        public bool IsRequired(ICustomObject oldReq, ICustomObject newReq)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Comparison with the second field
        /// </summary>
        /// <param name="other">Second field object</param>
        /// <returns></returns>
        public bool Equals(IUserFieldDefinition other)
        {
            if (other == null)
                return false;
            return Id == other.Id;
        }
        /// <inheritdoc/>
        public void Save()
        {
            _id = OnSave();
        }
        /// <summary>
        /// Save method definition
        /// </summary>
        /// <returns>
        /// Field identifier
        /// <seealso cref="Id"/>
        /// </returns>
        protected abstract int OnSave();
    }
}
