using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetStateInformation.Classes
{
    public class StateRequest
    {
        private List<StateInformation> stateList;

        public  List<StateInformation> StateList
        {
            get { return stateList; }
            set { stateList = value; }
        }

        public string statusCode { get; set; }
        public string statusDescription { get; set; }
        public string capital { get; set; }
        public string largestCity { get; set; }

        public void submitRequest(string url)
        {
            try
            {
                string content = string.Empty;
                List<StateInformation> states = new List<StateInformation>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode=response.StatusCode.ToString();
                statusDescription = response.StatusDescription.ToString();
                Stream stream = response.GetResponseStream();
                var streamReader = new StreamReader(stream);
                content = streamReader.ReadToEnd();
                var stateSet = JsonConvert.DeserializeObject<ResponseClass>(content);
                stateList = stateSet.results.States;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Request to API FAILED");
                stateList = null;
            }
        }

        public void GetCapitalLargestCity(string inputString=null)
        {
            if (!String.IsNullOrEmpty(inputString.Trim()))
            {
                if (stateList!=null)
                {
                    var a = stateList
                            .Where(x => x.abbr.Equals(inputString, StringComparison.CurrentCultureIgnoreCase) ||
                                x.name.Equals(inputString, StringComparison.CurrentCultureIgnoreCase))
                            .Select(x => new { x.capital, x.largestCity });
                    if (a.FirstOrDefault() != null)
                    {
                        capital = a.FirstOrDefault().capital;
                        largestCity = a.FirstOrDefault().largestCity;
                        Console.WriteLine("State Captial: " + capital);
                        Console.WriteLine("Largest City: " + largestCity + "\n");
                    }
                    else
                        Console.WriteLine("No matching state found \n");
                }
                else
                    Console.WriteLine("API did not return State list \n");
            }

        }
    }
}
