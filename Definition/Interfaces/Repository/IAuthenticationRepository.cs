using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces.Repository
{
    public interface IAuthenticationRepository
    {
		Task<Result<Users>> Me(string token);
        Task<Result<string>> Login(string email, string password);
    }
}
