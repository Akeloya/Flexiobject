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
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbProvider.Entities
{
    [Table("ObjectsHistory")]
    public class ObjectHistory
    {
        [Key]
        public int Id { get; private set; }
        [Column("Object_id")]        
        public long ObjectId { get; private set; }
        public DateTime ChangeDate { get; private set; }
        public int ModifiedBy { get; private set; }
        public short Attribute { get; private set; }
        public int UserField { get; private set; }
        [Column("nvarchar(265)")]
        public string OldValue { get; private set; }
        [Column("nvarchar(265)")]
        public string NewValue { get; private set; }
        public int State { get; private set; }
        public short Formant { get; private set; }
    }
}
