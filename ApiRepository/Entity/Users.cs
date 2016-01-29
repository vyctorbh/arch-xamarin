using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository.Entity
{
    public class Users
    {
        public string user { get; set; }
        public string access_token { get; set; }
        public string name { get; set; }
        public string URL { get; set; }
        public string error { get; set; }
    }
}
