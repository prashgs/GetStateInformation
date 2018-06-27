using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GetStateInformation.Classes
{
    public class ResponseClass
    {
        [JsonProperty("RestResponse")]
        public Results results { get; set; }
    }

    public class Results
    {
        //[JsonProperty("messages")]
        //public List<string> Messages { get; set; }

        [JsonProperty("result")]
        public List<StateInformation> States { get; set; }
    }

    public class StateInformation
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("abbr")]
        public string abbr { get; set; }

        [JsonProperty("largest_city")]
        public string largestCity { get; set; }

        [JsonProperty("capital")]
        public string capital { get; set; }
    }
}
