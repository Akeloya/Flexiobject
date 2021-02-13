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


using DbProvider.Entities;

namespace DbProvider
{
    public partial class ImportFolderSettgs
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public short ImportType { get; set; }
        public bool UseCreationRule { get; set; }
        public bool CacheAllObjects { get; set; }
        public bool IncludeSubfolders { get; set; }
        public int? PerformanceFlags { get; set; }
        public int BulkSize { get; set; }
        public bool IgnoreBasefilter { get; set; }
        public bool CompatibilityFlag { get; set; }
        public bool IdFieldsNull { get; set; }
        public int FieldId { get; set; }
        public int SettingId { get; set; }
        public virtual ImportSettings Setting { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
