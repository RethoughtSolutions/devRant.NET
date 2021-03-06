//     File:  devRant.NET/devRant.NET/Parameter.cs
//     Copyright (C) 2017 Rethought
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//     Created: 04.09.2017 3:43 AM
//     Last Edited: 04.09.2017 11:39 AM

namespace devRant.NET
{
    public class Parameter : IParameter
    {
        public Parameter(string keyword, string value)
        {
            this.Keyword = keyword;
            this.Value = value;
        }

        public string Keyword { get; set; }

        public string Value { get; set; }

        public string Get()
        {
            return $"{this.Keyword}={this.Value}";
        }
    }
}