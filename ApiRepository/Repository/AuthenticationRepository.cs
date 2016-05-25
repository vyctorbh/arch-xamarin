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


        public async Task<Result<string>> Login(string email, string password)
        {
            using (var client = new RestClient(_client.BaseAddress))
            {
                var request = new RestRequest("wp-json/", HttpMethod.Get);

                string user = email + ":" + password;
                var plainTextByte = System.Text.Encoding.UTF8.GetBytes(user);
                var userbase64 = Convert.ToBase64String(plainTextByte);
                string hed = "Basic " + userbase64;
                request.AddHeader("Authorization", hed);

				/*return new Result<string>()
				{
					Success = true,
					Value = hed
				};*/

                client.IgnoreResponseStatusCode = true;
                bool error = false;

                try {
                    var result = await client.Execute<Users>(request);
                    if (result.StatusCode == HttpStatusCode.Unauthorized || !String.IsNullOrEmpty(result.Data.error))
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
                            Value = hed
                        };
                    }
                }
                catch(Exception ex)
                {
                    return new Result<string>()
                    {
                        Success = false,
                        Value = "Email e/ou Senha inválidos..."
                    };
                }

                
            }
        }

    }
}

