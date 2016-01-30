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

        }
    }
}