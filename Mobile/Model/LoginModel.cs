using Definition.Interfaces;
using Definition.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Model;

namespace Mobile.Model
{
    public class LoginModel : BaseModel
    {
        IAuthenticationService _authenticationService;

        public LoginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Value { get; set; }
		public Users user
		{
			get;
			set;
		}
		public string Token
		{
			get;
			set;
		}
        public async Task Authenticate()
        {
            var auth = await _authenticationService.Authenticate(Email, Password);
            IsAuthenticated = auth.Success;
            Value = auth.Mensagem;
        }

		public async Task Me()
		{
			var auth = await _authenticationService.Me(Token);
			user = auth;
		}

    }
}
