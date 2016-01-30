using Sitecore;
using Sitecore.Data;
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
        private Item _dataset;
        public Item InnerItem
        {
            get { return _dataset; }
        }
        public DataSet(Item dataset)
        {
            Assert.IsTrue(dataset.IsDerived(Templates.DataSet.ID),
                string.Format("'{0}' must be derrived from '{1}'", nameof(dataset), Templates.Repository.ID));
            _dataset = dataset;
        }

        public ID IDs
        {
            get
            {
                return _dataset.ID;
            }
        }

        //-	OpenDataSourceType
        /// <summary>
        /// The type of the aggregation provider. 
        /// Will return null if unspecified.
        /// Will return null and log an exception if specified incorrectly.
        /// </summary>
        public Type AggregationProvider
        {
            get
            {
                var typeString = StringUtil.GetString(_dataset[Templates.DataSet.AggregationProvider], string.Empty);
                if (string.IsNullOrEmpty(typeString))
                {
                    return null; // No type to work with.
                }
                try
                {
                    return Type.GetType(typeString);
                }
                catch (Exception ex)
                {
                    // Log the error and allow the site to keep running as if this had been empty the whole time.
                    Log.Error(string.Format("Error reading type for dataset '{0}'", _dataset.ID), ex);
                    return null;
                }
            }
        }
        //-	Source(url or media item)
        public Dictionary<string, string> Parameters
        {
            get
            {
                var paramString = StringUtil.GetString(_dataset[Templates.DataSet.ProviderConfig], string.Empty);
                if (string.IsNullOrEmpty(paramString))
                {
                    // Return an empty dictionary so that dependent code only needs to check for the existence of its' own parameters.
                    return new Dictionary<string, string>();
                }
                else
                {
                    // Sanitize newline characters - I remember having carriage return problems with SC 8.0
                    // Can't be bothered testing what SC 8.1 does.
                    var paramLines = paramString.Replace('\r', '\n').Replace("\n\n", "\n").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    // Check for only things in valid format.
                    var validPrameters = paramLines.Select(x => x.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)).Where(x => x.Count() == 2);

                    // Reformat as a dictionary.
                    return validPrameters.ToDictionary(x => x[0], x => x[1]);
                }
            }
        }

        //-	Facet Name
        public string Name
        {
            get
            {
                return StringUtil.GetString(_dataset[Templates.DataSet.FacetName], string.Empty);
            }
        }
        //-	DataPointType
        public IEnumerable<DataPoint> Points
        {
            get
            {
                return _dataset.Children.Select(x => new DataPoint(x));
            }
        }
        //-	Colour
        public string Colour
        {
            get
            {
                return StringUtil.GetString(_dataset[Templates.DataSet.FacetName], string.Empty);
            }
        }
        public enum eFacetType { Markers, Polygon, Heatmap }
        public eFacetType FacetType
        {
            get
            {
                return (eFacetType) Enum.Parse(typeof(eFacetType), StringUtil.GetString(_dataset, "Markers"));
            }
        }
    }
}