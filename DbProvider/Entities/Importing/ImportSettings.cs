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


namespace Flexiobject.DbProvider
{
    public partial class ImportSettings
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string SqlStatement { get; set; }
        public int User { get; set; }
        public short DataSourceType { get; set; }
        public bool LogErrors { get; set; }
        public string LogfilePrefix { get; set; }
        public string Logpath { get; set; }
        public bool UseSql { get; set; }
        public short Flags { get; set; }
        public bool ReflistFull { get; set; }
        public bool RemoveRefs { get; set; }
        public string IdColumns { get; set; }
    }
}
