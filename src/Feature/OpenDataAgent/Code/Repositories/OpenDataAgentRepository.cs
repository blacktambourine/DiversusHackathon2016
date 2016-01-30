using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Diversus.Hackathon2016.Foundation.OpenDataAgent.Models;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent.Repositories
{
    public class OpenDataAgentRepository
    {
        private Repository _internalRepository;
        public OpenDataAgentRepository(ID repositoryID, Database database)
        {
            Assert.IsNotNull(database, "Sitecore context cannot be null");
            _internalRepository = new Repository(repositoryID, database);
        }
        public OpenDataAgentRepository(Repository repository)
        {
            Assert.IsNotNull(repository, "OpenData Repository cannot be null");
            _internalRepository = repository;
        }
        public IEnumerable<DataSet> GetDataSets()
        {
            return _internalRepository.Datasets;
        }
        public static IEnumerable<OpenDataAgentRepository> GetRepositoriesUnderPath(string path, Database database)
        {
            return database.SelectItems(path).Where(x => x.IsDerived(Templates.Repository.ID)).Select(x=> new OpenDataAgentRepository(new Repository(x)));
        }
    }
}