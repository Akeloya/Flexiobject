/*
 *  "Flexiobject database provider"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ObjectFolder")]
    public class ObjectFolder
    {
        public ObjectFolder()
        {
            FieldDefinitions = new HashSet<FieldDefinition>();
            SummaryDefinition = new HashSet<SummaryDefinition>();
            ListProperties = new HashSet<ListProperty>();
            WfStates = new HashSet<WfState>();
            HistoriEntries = new HashSet<SchemaHistory>();
            WfStateTransitions = new HashSet<WfStateTransition>();
            Actions = new HashSet<ModifyAction>();
        }
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }        
        public string NamingScheme { get; set; }
        public bool InheritNs { get; set; }
        public int ParentId { get; set; }
        public int OpenPictureId { get; set; }
        public int ClosePictureId { get; set; }
        public int? WfHistoryFieldId { get; set; }
        public virtual Picture PictureOpen { get; set; }
        public virtual Picture PictureClose { get; set; }
        [NotMapped]
        public WfState WfHistoryField { get; set; }
        public virtual ObjectFolder Parent { get; set; }
        public virtual ICollection<FieldDefinition> FieldDefinitions { get; set; }
        public virtual ICollection<SummaryDefinition> SummaryDefinition { get; set; }
        public virtual ICollection<ListProperty> ListProperties { get; set; }
        public virtual ICollection<WfState> WfStates { get; set; }
        public virtual ICollection<ObjectDef> Objects { get; set; }
        public virtual ICollection<SchemaHistory> HistoriEntries { get; set; }
        public virtual ICollection<Privilege> Privileges { get; set; }
        public virtual ICollection<WfStateTransition> WfStateTransitions { get; set; }
        public virtual ICollection<ModifyAction> Actions { get; set; }
    }
}
