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
using Core.Enumes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbProvider.Entities
{
    [Table("FolderFieldDefinition")]
    public class FolderFieldDefinition
    {
        [Key]
        public int Id { get; private set; }
        public int ObjectType { get; private set; }
        [Column(TypeName = "nvarchar(80)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        [Required]
        public string Alias { get; set; }
        [Column(TypeName = "byte")]
        [Required]
        public CoaEnumFieldType FieldType { get; private set; }
        public bool LogChanges { get; set; }
        public int ObjectTypeReference { get; set; }
        public short DataProperties { get; set; }
        public bool SyncronizedField { get; set; }
        public bool IsQuicksearch { get; set; }
        public short MinSize { get; set; }
        public short MaxSize { get; set; }
        public bool IndexDb { get; set; }
        public bool HasRestriction { get; set; }
        public bool HasRestrictionScript { get; set; }
        public int RestrictionScriptId { get; set; }
        [MaxLength(256)]
        public string RestrictionErrMsg { get; set; }
        [MaxLength(100)]
	    public string MatchExpression { get; set; }
    }
}
