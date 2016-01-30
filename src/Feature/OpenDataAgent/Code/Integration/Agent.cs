using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Diversus.Hackathon2016.Foundation.OpenDataAgent.Models;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    var providerType = dataset.AggregationProvider;
                    if(providerType == null)
                    {
                        continue;
                    }
                    if(typeof(IDataProvider).IsAssignableFrom(providerType))
                    {
                        IDataProvider provider = (IDataProvider)Activator.CreateInstance(providerType);

                        try
                        {
                            // Temporary hack while this interface is changing
                            var items = provider.Execute(dataset.Parameters, dataset.Parameters["webApiUrl"]);
                            if (items != null && items.Count() > 0)
                            {
                                using (new SecurityDisabler())
                                {
                                    dataset.InnerItem.DeleteChildren();
                                    foreach (var item in items)
                                    {
                                        try
                                        {
                                            var result = new DataPoint(item, dataset);
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error(string.Format("Error importing single line of data from {0}", dataset.Name), ex);
                                        }
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Log.Error(string.Format("Error importing items for {0}", dataset.Name), ex);
                        }

                    }
                }
            }
        }
    }
}