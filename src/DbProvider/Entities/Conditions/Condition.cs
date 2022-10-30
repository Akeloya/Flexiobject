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
using System.ComponentModel.DataAnnotations.Schema;
using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    [Table("Conditions")]
    public partial class Condition
    {
        public int Id { get; set; }
        public int Rule { get; set; }
        public CoaRuleCombinationTerms Operator { get; set; }
        public Condition Parent { get; set; }
        public byte Property { get; set; }
        public int KeyProperty { get; set; }
        public CoaRuleComparisonsTypes Comparison { get; set; }
        public string ParamName { get; set; }
        public bool? MatchAll { get; set; }
        public byte? PropertyFlag { get; set; }
        public short? ParamPos { get; set; }
    }
}
