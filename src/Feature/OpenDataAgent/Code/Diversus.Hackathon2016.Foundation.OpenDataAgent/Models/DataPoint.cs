using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent.Models
{
    public class DataPoint
    {
        Item _item;
        public DataPoint(Item item)
        {
            Assert.IsTrue(item.IsDerived(Templates.DataPoint.ID), $"item must derive {0}",Templates.DataPoint.ID);
            _item = item;
        }
        public IEnumerable<LocationPoint> Points
        {
            get
            {
                var raw = StringUtil.GetString(_item[Templates.DataPoint.Points], string.Empty);
                return raw.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(LocationPoint.FromString);
            }
            set
            {
                _item[Templates.DataPoint.Points] = string.Join("|", value);
            }
        }
        public string Title
        {
            get
            {
                return StringUtil.GetString(_item[Templates.DataPoint.Title]);
            }
            set
            {
                _item[Templates.DataPoint.Title] = value;
            }
        }
        public class LocationPoint
        { 
            public static LocationPoint FromString(string pair)
            {
                var array = pair.Split(',');
                return new LocationPoint
                {
                    Lat = MainUtil.GetFloat(array[0], -31.954891f),
                    Lng = MainUtil.GetFloat(array[1], 115.858424f)
                };
            }
            public float Lat { get; set; }
            public float Lng { get; set; }
            public override string ToString()
            {
                return string.Format("{0},{1}", Lat, Lng);
            }
        }
    }
}