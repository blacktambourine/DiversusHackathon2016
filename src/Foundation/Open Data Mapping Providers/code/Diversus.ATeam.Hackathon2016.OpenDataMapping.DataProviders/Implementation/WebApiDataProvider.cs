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
        private JObject _sourceData;

        /* Public Properties ========================================== */

        public string WebAPIUrl { get; set; }

        /* Constructor ===================== */

        public WebApiDataProvider(string requestUrl)
        {
            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentException("requestUrl must not be empty");

            this.WebAPIUrl = requestUrl;
        }

        /* Private methods ============================================ */

        public JObject MakeRequest(string requestUrl)
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

        

        /* Interface method implementations =========================== */
        public void AccessSource()
        {
            this._sourceData = this.MakeRequest(this.WebAPIUrl);
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

        public void ValidateSourceData(Dictionary<string, string> fieldsToMap)
        {
            //_sourceData.

            throw new NotImplementedException();
        }
    }
}
