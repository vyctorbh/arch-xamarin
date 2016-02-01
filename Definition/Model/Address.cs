using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Definition.Model
{
    public class Address
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string date { get; set; }
        public string content { get; set; }
        //public string qtdrows { get; set; }
        [JsonProperty(PropertyName = "featured_image")]
        public featured_image image { get; set; }
    }
    public class featured_image
    {
        public string guid { get; set; }
    }
}
