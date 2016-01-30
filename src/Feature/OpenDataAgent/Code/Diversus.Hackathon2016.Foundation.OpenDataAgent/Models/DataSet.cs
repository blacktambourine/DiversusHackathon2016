using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent.Models
{
    public class DataSet
    {
        public DataSet(Item dataset)
        {
            Assert.IsTrue(dataset.IsDerived(Templates.DataSet.ID),
                string.Format("'{0}' must be derrived from '{1}'", nameof(dataset), Templates.Repository.ID));
        }
        //-	OpenDataSourceType
        public string AggregationProvider { get; set; }
        //-	Source(url or media item)
        public string Parameters { get; set; }
        //-	Facet Name
        public string Name { get; set; }
        //-	DataPointType
        public string Coordinates { get; set; }
        //-	Colour
        public string Color { get; set; }
    }
}