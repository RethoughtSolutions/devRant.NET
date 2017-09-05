//     File:  devRant.NET/devRant.NET/RantsResponse.cs
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
//     Created: 03.09.2017 1:09 PM
//     Last Edited: 04.09.2017 11:39 AM

#region Using Directives

using System.Collections.Generic;

using Newtonsoft.Json;

#endregion

namespace devRant.NET
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RantsResponse : IResponse
    {
        [JsonProperty("news", Required = Required.Always)]
        public News News { get; set; }

        [JsonProperty("rants", Required = Required.Always)]
        public List<Rant> Rants { get; set; }

        [JsonProperty("set", Required = Required.Always)]
        public string Set { get; set; }

        [JsonProperty("settings", Required = Required.Always)]
        public List<object> Settings { get; set; }

        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }


        [JsonProperty("wrw", Required = Required.Always)]
        public int Wrw { get; set; }
    }
}