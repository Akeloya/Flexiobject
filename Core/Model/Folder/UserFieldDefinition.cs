/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
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
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CoaApp.Core
{
    public abstract class CoaUserFieldDefinition : AppBase, IUserFieldDefinition
    {
        protected CoaUserFieldDefinition(IApplication app, object parent): base(app, parent)
        {

        }
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
        public static IUserFieldDefinition GetFieldByPath(ICustomFolder startFolder, string fieldPath)
        {
            return GetFieldsByPath(startFolder, fieldPath).Last();
        }
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
        public int Id => throw new NotImplementedException();

        public string Alias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public dynamic Details => throw new NotImplementedException();

        public CoaFieldTypes Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool WriteHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object DefaultValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanEditFieldType => throw new NotImplementedException();

        public bool UseRuleRequired { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseRuleEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRule RequiredRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRule EnabledRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IndexFieldDb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IndexField { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsEnabled(ICustomObject oldReq, ICustomObject newReq)
        {
            throw new NotImplementedException();
        }

        public bool IsRequired(ICustomObject oldReq, ICustomObject newReq)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
