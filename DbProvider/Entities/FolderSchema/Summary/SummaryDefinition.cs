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

namespace DbProvider.Entities
{
    public partial class SummaryDefinition
    {
        public SummaryDefinition()
        {
            SummaryAddFields = new HashSet<SummaryAddFields>();
            SummaryFieldSteps = new HashSet<SummaryFieldSteps>();
            SummaryResultFields = new HashSet<SummaryResultFields>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public int? RefField { get; set; }
        public int? ScriptId { get; set; }
        public int? ModifObjFlags { get; set; }
        public bool? RecalcAfterRemove { get; set; }
        public bool? StoreZero { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual ICollection<SummaryAddFields> SummaryAddFields { get; set; }
        public virtual ICollection<SummaryFieldSteps> SummaryFieldSteps { get; set; }
        public virtual ICollection<SummaryResultFields> SummaryResultFields { get; set; }
    }
}
