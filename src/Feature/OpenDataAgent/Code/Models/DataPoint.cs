using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
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
        //Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Models
        public DataPoint(Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Models.DataPoint datapoint, DataSet set)
        {
            // Too tired to write this code properly
            TemplateItem template = Sitecore.Configuration.Factory.GetDatabase("master").GetTemplate(Templates.DataPoint.ID);

            Item _item = ItemManager.CreateItem(datapoint.Title, set.InnerItem, template.ID);
            
            _item.Editing.BeginEdit();
            this.Point = new LocationPoint(MainUtil.GetFloat(datapoint.Latitude, 0.0f), MainUtil.GetFloat(datapoint.Longitude,0.0f));
            this.Title = datapoint.Title;
            _item.Editing.EndEdit();
        }
        public DataPoint(Item item)
        {
            Assert.IsTrue(item.IsDerived(Templates.DataPoint.ID), $"item must derive {0}",Templates.DataPoint.ID);
            _item = item;
        }
        public LocationPoint Point
        {
            get
            {
                var raw = StringUtil.GetString(_item[Templates.DataPoint.Points], string.Empty);
                return LocationPoint.FromString(raw);
            }
            set
            {
                _item[Templates.DataPoint.Points] = value.ToString();
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
            public LocationPoint() { }
            public LocationPoint(float lat, float lng)
            {
                Lat = lat;
                Lng = lng;
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