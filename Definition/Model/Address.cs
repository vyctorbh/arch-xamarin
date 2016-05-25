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
		[JsonProperty(PropertyName = "id_post")]
        public int ID { get; set; }
		[JsonProperty(PropertyName = "title")]
        public string title { get; set; }
		[JsonProperty(PropertyName = "link")]
        public string link { get; set; }
		[JsonProperty(PropertyName = "niceDate")]
        public string date { get; set; }
		[JsonProperty(PropertyName = "alt_img")]
        public string content { get; set; }
        //public string qtdrows { get; set; }
		[JsonProperty(PropertyName = "src_img")]
        public string image { get; set; }
    }
    public class featured_image
    {
        public string guid { get; set; }
    }
}
