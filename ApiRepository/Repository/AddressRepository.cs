using ApiRepository.Entity;
using Definition.Interfaces.Repository;
using Definition.Model;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository.Repository
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public string numberpage { get; set; }
        public string skippage { get; set; }

        public AddressRepository(string baseUrl)
        {
            _client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<Result<Address>> Search(string search, string latitude, string longitude)
        {
            using (var client = new RestClient(_client.BaseAddress))
            {
                var request = new RestRequest("search", HttpMethod.Get);
                request.AddParameter("address", search);
                request.AddParameter("numberpage", numberpage);
                request.AddParameter("skippage", skippage);

                client.IgnoreResponseStatusCode = true;

                var result = await client.Execute<List<Address>>(request);

                return new Result<Address>() { Success = true, Values = result.Data };
            }
        }
    }
}
