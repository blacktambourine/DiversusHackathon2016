using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Helpers
{
    public class UrlHelper
    {
        /// <summary>
        /// Create the RESTful request URL
        /// </summary>
        /// <param name="queryStringParams"></param>
        /// <returns>Complete REST request url</returns>
        public static string CreateRESTRequestURL(string url, string[] queryStringParams)
        {
            string urlRequest = url;

            // Ensure we have trailing forward slash
            if (!urlRequest.EndsWith(@"/"))
                urlRequest += @"/";

            foreach (var qString in queryStringParams)
                urlRequest += qString + @"/";


            return (urlRequest);
        }
    }
}
