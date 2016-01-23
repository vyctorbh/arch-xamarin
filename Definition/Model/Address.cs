using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Model
{
    public class Address
    {
        public int id { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string numberhome { get; set; }
        public string qtdrows { get; set; }
        public Cidade cidade { get; set; }
    }

    public class Cidade
    {
        public string nome { get; set; }
    }
}
