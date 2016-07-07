using Definition.Interfaces.Repository;
using Definition.Interfaces.Service;
using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// Will be used to authenticate with the API. This example uses REST and JWT
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<Auth> Authenticate(string email, string password)
        {
            var result = await _authenticationRepository.Login(email, password);
            Auth auth = new Auth();
            auth.Success = result.Success;
            auth.Mensagem = result.Value;

            return auth;
        }

		public async Task<Users> Me(string token)
		{
			var result = await _authenticationRepository.Me(token);
			Users auth = new Users();
			auth = result.Values.First();

			return auth;
		}

    }
}
