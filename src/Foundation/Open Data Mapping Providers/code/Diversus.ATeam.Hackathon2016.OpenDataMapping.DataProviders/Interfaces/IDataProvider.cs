using Diversus.ATeam.Hackathon2016.OpenDataMApping.DataProviders.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces
{
    public interface IDataProvider
    {
        List<DataPoint> Execute(Dictionary<string, string> fieldsToMap, string webApiUrl);

    }
}
