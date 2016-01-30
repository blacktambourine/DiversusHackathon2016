using Diversus.Hackathon2016.Foundation.OpenDataAgent.Models;
using System.Collections.Generic;
using System.Linq;

namespace Diversus.Feature.OpenDataMap.Models
{
    public class Map
    {
        public Map(Repository repo)
        {
            int i = 0;
            Facets = repo.Datasets.Select(x => new Facet(x, i++));
            DefaultZoom = repo.Zoom;
            DefaultLong = repo.Longitude;
            DefaultLat = repo.Lattitude;
        }
        public int DefaultZoom { get; set; }
        public float DefaultLong { get; set; }
        public float DefaultLat { get; set; }
        public IEnumerable<Facet> Facets { get; set; }

        public class Location
        {
            public Location(string _title, DataPoint.LocationPoint point)
            {
                title = _title;
                lat = point.Lat;
                lng = point.Lng;
            }
            public string title { get; set; }
            public float lat { get; set; }
            public float lng { get; set; }
        }
        public class Facet
        {
            public Facet(DataSet data, int index)
            {
                FacetId = index;
                FacetName = data.Name;
                Colour = data.Colour;
                Locations = data.Points.Select(x => new Location(x.Title, x.Point));
            }
            public int FacetId { get; set; }
            public string FacetType { get; set; }
            public string FacetName { get; set; }
            public string Colour { get; set; }
            public IEnumerable<Location> Locations { get; set; }
        }
    }
}