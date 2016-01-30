using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Helpers;
using Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Models;

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



        

        /* Interface method implementations =========================== */
        public List<DataPoint> Execute(Dictionary<string,string> fieldsToMap, string webApiUrl)
        {

            // Make the request and get the response
            var jsonResonse = RequestHelper.MakeRequest(webApiUrl);

            // TODO : validate response?


            
            Dictionary<System.Reflection.PropertyInfo, List<JToken>> mappingPropertyInfoDictionary = new Dictionary<System.Reflection.PropertyInfo, List<JToken>>();
            int numberOfTokens = 0;

            foreach (var entry in fieldsToMap)
            {
                System.Reflection.PropertyInfo dataPointPropertyInfo = typeof(DataPoint).GetProperty(entry.Value);

                var listOfTokens = jsonResonse.SelectTokens(entry.Key).ToList();

                numberOfTokens = listOfTokens.Count;

                mappingPropertyInfoDictionary.Add(dataPointPropertyInfo, jsonResonse.SelectTokens(entry.Key).ToList());
            }

            // collapse all values
            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < numberOfTokens; i++)
            {
                var dp = new DataPoint();

                //dp.Title = mappingPropertyInfoDictionary.ElementAt(0).Value[i].Value<string>();

                //var locationPoint = new DataPoint.LocationPoint();
                //locationPoint.Lat = (float)Convert.ToDouble(mappingPropertyInfoDictionary.ElementAt(1).Value[i].ToString());
                //locationPoint.Lat = (float)Convert.ToDouble(mappingPropertyInfoDictionary.ElementAt(2).Value[i].ToString());

                //dp.Locations.ToList().Add(locationPoint);

                foreach (var entry in mappingPropertyInfoDictionary)
                {
                    entry.Key.SetValue(dp, entry.Value[i].Value<string>());
                }

                dataPoints.Add(dp);
            }


            return dataPoints;
        }

        public class MappingPropertyInfo
        {
            public System.Reflection.PropertyInfo DataPointProperty { get; set; }
            public int MyProperty { get; set; }
        }

        public IEnumerable<DataPoint> Execute(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
