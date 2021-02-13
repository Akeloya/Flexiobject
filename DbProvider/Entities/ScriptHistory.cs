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

namespace DbProvider.Entities
{
    public partial class ScriptHistory
    {
        public int Id { get; set; }
        public virtual Script SourceScript { get; set; }
        public string Script { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int? PublishedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Published { get; set; }
        public bool IsPublished { get; set; }
    }
}
