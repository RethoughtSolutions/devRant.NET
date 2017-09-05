//     File:  devRant.NET/devRant.NET.Test/Class1.cs
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
//     Created: 04.09.2017 6:33 AM
//     Last Edited: 04.09.2017 10:19 AM

#region Using Directives

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

using Newtonsoft.Json;

using NUnit.Framework;

#endregion

namespace devRant.NET.Test
{
    [TestFixture]
    public class HttpClientIntegrationTests
    {
        private HttpConfiguration _httpConfiguration;

        private HttpServer _httpServer;

        [Test]
        public async Task Get_Rant_From_In_Memory_Web_Server_Not_Null()
        {
            var client = DevRantClient.Create(new HttpClient(this._httpServer));

            var rant = await client.GetRant(817768);

            Assert.IsNotNull(rant);
            Assert.IsTrue(rant.Success);
        }


        [Test]
        public async Task Get_Rants_From_In_Memory_Web_Server_Not_Null()
        {
            var client = DevRantClient.Create(new HttpClient(this._httpServer));

            var rant = await client.GetRants(Sort.Algo, 50, 0);

            Assert.IsNotNull(rant);
            Assert.IsTrue(rant.Success);
        }

        [Test]
        public async Task Search_Rant_From_In_Memory_Web_Server_Not_Null()
        {
            var client = DevRantClient.Create(new HttpClient(this._httpServer));

            var rant = await client.SearchRants("devRant");

            Assert.IsNotNull(rant);
            Assert.IsTrue(rant.Success);
        }

        [SetUp]
        public void Setup()
        {
            this._httpConfiguration = new HttpConfiguration();

            this._httpConfiguration.MapHttpAttributeRoutes();

            this._httpServer = new HttpServer(this._httpConfiguration);
        }

        [Test]
        public async Task Setup_Http_Client_And_Check_For_Ok_Status()
        {
            var client = new HttpClient(this._httpServer);

            const string url = "http://devrant.io/";

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url + "api/status"),
                Method = HttpMethod.Get
            };

            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await client.SendAsync(request))
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }


    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("api/status/")]
        public IHttpActionResult GetStatus()
        {
            return this.Ok();
        }
    }

    public class RantsController : ApiController
    {
        [HttpGet]
        [Route("api/devrant/rants/surprise/")]
        public object GetSurprise()
        {
            using (var r =
                new StreamReader(
                    Path.GetFullPath(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "..\\..\\")) + "JSON/devrant/rants/surprise.json"))
            {
                return r.ReadToEnd();
            }
        }
    }

    public class DevRantController : ApiController
    {
        [HttpGet]
        [Route("api/devrant/rants/{id}")]
        public RantResponse GetRantByID(int id)
        {
            using (var r =
                new StreamReader(
                    Path.GetFullPath(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "..\\..\\")) + "JSON/devrant/rant.json"))
            {
                return JsonConvert.DeserializeObject<RantResponse>(
                    r.ReadToEnd());
            }
        }

        [HttpGet]
        [Route("api/devrant/rants/")]
        public RantsResponse GetRants(Sort sort, int limit, int skip)
        {
            using (var r =
                new StreamReader(
                    Path.GetFullPath(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "..\\..\\")) + "JSON/devrant/rants.json"))
            {
                return JsonConvert.DeserializeObject<RantsResponse>(
                    r.ReadToEnd());
            }
        }

        [HttpGet]
        [Route("api/devrant/search/")]
        public SearchRespone GetSearch(string term)
        {
            using (var r =
                new StreamReader(
                    Path.GetFullPath(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "..\\..\\")) + "JSON/devrant/search.json"))
            {
                return JsonConvert.DeserializeObject<SearchRespone>(
                    r.ReadToEnd());
            }
        }
    }
}