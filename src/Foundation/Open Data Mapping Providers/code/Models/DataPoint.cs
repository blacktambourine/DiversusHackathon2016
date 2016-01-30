using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Models
{
    public class DataPoint
    {
        public DataPoint() { }

        public DataPoint(string title, string lat, string lng)
        {
            Title = title;

            Locations = new List<LocationPoint>();

            Longitude = lng;
            Latitude = lat;
           
        }
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public IEnumerable<LocationPoint> Locations { get; set; }
        public class LocationPoint
        {
            public float Lat { get; set; }
            public float Lng { get; set; }
        }
    }
}
