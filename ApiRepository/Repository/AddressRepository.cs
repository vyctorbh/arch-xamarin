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

			_client.BaseAddress = new Uri("http://afrig.com.br/api/service.php/");
        }

        public async Task<Result<Address>> Search(string search, string latitude, string longitude)
        {
			Uri url = _client.BaseAddress;
			url = new Uri("http://afrig.com.br/api/service.php/");
			string category = "1";
			if(search.Contains("Intercarnes"))
			{
				category = "9";
			}
			if(search.Contains("Cotacao"))
			{
				category = "11";
			}
			if(search.Contains("Tabela"))
			{
				category = "10";
			}
			using (var client = new RestClient(_client.BaseAddress+"wp_posts?category="+category))
            {
				var request = new RestRequest(HttpMethod.Get);
                //request.AddHeader("Authorization", latitude);
                //request.AddParameter("filter[s]", search);

                client.IgnoreResponseStatusCode = true;

                var result = await client.Execute<List<Address>>(request);

                return new Result<Address>() { Success = true, Values = result.Data };
            }
        }
    }
}
