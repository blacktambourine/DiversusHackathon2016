using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Models
{
    public class DataPoint
    {
        public DataPoint(string title, LocationPoint point)
        {
            Title = title;
            Location =  point;
        }
        public string Title { get; set; }
        public LocationPoint Location { get; set; }
        public class LocationPoint
        {
            public float Lat { get; set; }
            public float Lng { get; set; }
        }
    }
}
