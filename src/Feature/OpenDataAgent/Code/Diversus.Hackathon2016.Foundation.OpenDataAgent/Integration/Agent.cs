using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Diversus.Hackathon2016.Foundation.OpenDataAgent.Models;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent.Integration
{
    public class Agent
    {
        public string Message { get; set; }
        public void Run(params string[] paths)
        {
            if(paths.Any())
            {
                foreach(var path in paths)
                {
                    UpdateAnyOpenDataRepositories(path);
                }
            }
            else
            {
                // Inefficient default of recursing everything under the content node.
                UpdateAnyOpenDataRepositories("/sitecore/content//*");
            }
        }

        private void UpdateAnyOpenDataRepositories(string path)
        {
            var masterDatabase = Sitecore.Configuration.Factory.GetDatabase("master");
            var repos = masterDatabase.SelectItems(path).Where(x=> x.IsDerived(Templates.Repository.ID)).Select(x=> new Repository(x));

            foreach(var repo in repos)
            {
                foreach(var dataset in repo.Datasets)
                {
                    var provider = dataset.AggregationProvider;

                    if(typeof(IDataProvider).IsAssignableFrom(provider))
                    {

                    }
                }
            }
        }
    }
}