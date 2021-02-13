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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using CoaApp.Core.Enumes;

namespace DbProvider.Entities
{
    [Table("FieldDefinitions")]
    public partial class FieldDefinition
    {
        public FieldDefinition()
        {
            ListProperties = new HashSet<ListProperty>();
            Status = new HashSet<WfState>();
            StateTransitions = new HashSet<WfStateTransition>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public CoaFieldTypes Type { get; set; }
        public bool WriteHistory { get; set; }
        public virtual ObjectFolder FolderReference { get; set; }
        public int DataProperty { get; set; }
        public int QuicksearchField { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public bool IndexDb { get; set; }
        public bool Restriction { get; set; }
        public bool RestrictionScript { get; set; }
        public int RestrictionScriptId { get; set; }
        public string RestrictionErrMsg { get; set; }
        public string RestrictionMutch { get; set; }
        public bool IsSyncronized { get; set; }
        public int FolderId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual ICollection<ListProperty> ListProperties { get; set; }
        public virtual ICollection<WfState> Status { get; set; }
        public virtual ICollection<WfStateTransition> StateTransitions { get; set; }
    }
}
