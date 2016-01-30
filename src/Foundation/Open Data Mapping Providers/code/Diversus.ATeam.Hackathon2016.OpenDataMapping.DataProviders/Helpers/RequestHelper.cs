using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Helpers
{
    public static class RequestHelper
    {
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
                throw e;
            }
        }
    }
}
