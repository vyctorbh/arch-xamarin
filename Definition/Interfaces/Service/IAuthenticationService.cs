using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces.Service
{
    public interface IAuthenticationService
    {
        Task<Auth> Authenticate(string email, string password);
    }
}
