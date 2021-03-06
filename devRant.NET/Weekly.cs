//     File:  devRant.NET/devRant.NET/Weekly.cs
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
//     Created: 04.09.2017 4:08 AM
//     Last Edited: 04.09.2017 11:39 AM

#region Using Directives

using Newtonsoft.Json;

#endregion

namespace devRant.NET
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Weekly
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("week")]
        public int Week { get; set; }
    }
}