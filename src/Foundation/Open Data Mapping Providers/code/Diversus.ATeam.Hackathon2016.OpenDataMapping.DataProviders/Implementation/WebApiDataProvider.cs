using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Implementation
{
    public class WebApiDataProvider : IDataProvider
    {
        /* Private instance variables ================================= */
        private string _webApiUrl;


        /* Private methods ============================================ */

        private void DoPost(string url)
        {

        }

        public static JObject MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string strsb = sr.ReadToEnd();
                    JObject objResponse = JsonConvert.DeserializeObject(strsb) as JObject; //(strsb, JSONResponseType);

                    return objResponse;
                }
            }
            catch (Exception e)
            {
                // TODO : How to better handle exceptions?

                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Create the RESTful request URL
        /// </summary>
        /// <param name="queryStringParams"></param>
        /// <returns>Complete REST request url</returns>
        public string CreateRESTRequestURL(string[] queryStringParams)
        {
            string urlRequest = _webApiUrl;

            // Ensure we have trailing forward slash
            if (!urlRequest.EndsWith(@"/"))
                urlRequest += @"/";

            foreach (var qString in queryStringParams)
                urlRequest += qString + @"/";
            

            return (urlRequest);
        }

        /* Interface method implementations =========================== */
        public void AccessSource()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads configuration data, including web api URL to interrogate
        /// </summary>
        public void ReadConfig()
        {
            throw new NotImplementedException();
        }

        public void ReadSource()
        {
            throw new NotImplementedException();
        }

        public void TransformSourceData()
        {
            throw new NotImplementedException();
        }

        public void ValidateSourceData()
        {
            throw new NotImplementedException();
        }
    }
}
