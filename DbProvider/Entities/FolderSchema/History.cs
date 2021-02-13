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
using System.ComponentModel.DataAnnotations.Schema;

namespace DbProvider.Entities
{
    [Table("ObjHistory")]
    public partial class History
    {
        public int Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public byte Attribute { get; set; }
        public int? UserField { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int State { get; set; }
        public byte Format { get; set; }
        public long ObjectId { get; set; }
        public int ModifiedById { get; set; }
        public virtual ObjectDef Object { get; set; }
        public virtual AppUser ModifiedBy { get; set; }
    }
}
