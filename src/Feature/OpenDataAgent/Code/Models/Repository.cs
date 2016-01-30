using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent.Models
{
    public class Repository
    {
        // Properties
        private Item _item;
        public Repository(ID repositoryID, Database database)
        {
            Assert.IsNotNull(database, "Database cannot be null");
            _item = database.GetItem(repositoryID);
            Assert.IsTrue(_item.IsDerived(Templates.Repository.ID), 
                string.Format("'{0}' must be derrived from '{1}'", nameof(repositoryID), Templates.Repository.ID));
        }
        public Repository(Item item)
        {

            Assert.IsTrue(item.IsDerived(Templates.Repository.ID),
                string.Format("'{0}' must be derrived from '{1}'", nameof(item), Templates.Repository.ID));
            _item = item;
        }
        // Default properties to be used when rendering the Google map
        public float Longitude
        {
            get
            {
                return MainUtil.GetFloat(_item[Templates.Repository.Longitude], -31.954891f);
            }
        }
        public float Lattitude
        {
            get
            {
                return MainUtil.GetFloat(_item[Templates.Repository.Lattitude], 115.858424f);
            }
        }
        public int Zoom
        {
            get
            {
                return MainUtil.GetInt(_item[Templates.Repository.Zoom], 10);
            }
        }

        public IEnumerable<DataSet> Datasets
        {
            get
            {
                return _item.Children.Where(x => x.IsDerived(Templates.DataSet.ID)).Select(x => new DataSet(x));
            }
        }
    }
}