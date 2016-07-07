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
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {
        private string client_id { get; set; }
        private string secret_id { get; set; }

        public AuthenticationRepository(string baseUrl, string client_id, string secret_id)
        {
            _client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.client_id = client_id;
            this.secret_id = secret_id;

            _client.BaseAddress = new Uri(baseUrl);
        }

		public async Task<Result<Users>> Me(string token)
		{
			using (var client = new RestClient(_client.BaseAddress + "/api/v1"))
			{
				var request = new RestRequest("user/me", HttpMethod.Get);
				request.AddParameter("access_token", token);

				client.IgnoreResponseStatusCode = true;

				var result = await client.Execute<List<Users>>(request);

				return new Result<Users>() { Success = true, Values = result.Data };
			}
		}


        public async Task<Result<string>> Login(string email, string password)
        {
            using (var client = new RestClient(_client.BaseAddress))
            {
                var request = new RestRequest("oauth/token", HttpMethod.Post);
                request.AddParameter("username", email);
                request.AddParameter("password", password);
                request.AddParameter("grant_type", "password");
                request.AddParameter("client_id", this.client_id);
                request.AddParameter("client_secret", this.secret_id);

                client.IgnoreResponseStatusCode = true;

                var result = await client.Execute<Users>(request);

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new Result<string>()
                    {
                        Success = false,
                        Value = "Email e/ou Senha inválidos..."
                    };
                }
                else if (result.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return new Result<string>()
                    {
                        Success = false,
                        Value = "Error..."
                    };
                }
                else
                {
                    return new Result<string>()
                    {
                        Success = true,
                        Value = result.Data.access_token
                    };
                }
            }
        }

    }
}

