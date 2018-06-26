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
    public static class HttpRequestClass
    {
        private static List<StateInformation> stateList;

        public static List<StateInformation> StateList
        {
            get { return stateList; }
            set { stateList = value; }
        }


        public static void submitRequest(string url)
        {
            try
            {
                string content = string.Empty;
                List<StateInformation> states = new List<StateInformation>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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

        public static void GetCapitalLargestCity(string inputString)
        {
            if (!String.IsNullOrEmpty(inputString))
            {
                if (stateList!=null)
                {
                    var a = stateList
                            .Where(x => x.abbr.Equals(inputString, StringComparison.CurrentCultureIgnoreCase) ||
                                x.name.Equals(inputString, StringComparison.CurrentCultureIgnoreCase))
                            .Select(x => new { x.capital, x.largestCity });
                    if (a.FirstOrDefault() != null)
                    {
                        Console.WriteLine("State Captial: " + a.FirstOrDefault().capital);
                        Console.WriteLine("Largest City: " + a.FirstOrDefault().largestCity + "\n");
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
