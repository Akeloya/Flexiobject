﻿/*
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
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("SchemeFieldsDef")]
    public class SchemaFieldDefinition
    {
        public int Id { get; set; }
        public short FieldPosition { get; set; }
        public int FieldSize { get; set; }
        public string FieldName { get; set; }
        public short DataType { get; set; }
        public bool HasIndex { get; set; }
        public int SchemaDefId { get; set; }
        public virtual SchemeTableDefinition SchemeDef { get; set; }
    }
}