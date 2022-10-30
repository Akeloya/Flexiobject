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
using System;

namespace FlexiObject.DbProvider.Entities
{
    public partial class SchemaHistory
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Reference { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public byte Action { get; set; }
        public int DeletedReference { get; set; }
        public int DeletedArea { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public string Username { get; set; }
    }
}
