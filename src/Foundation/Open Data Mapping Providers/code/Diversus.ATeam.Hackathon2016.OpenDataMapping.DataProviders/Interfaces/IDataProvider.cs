using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Models;
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
        IEnumerable<DataPoint> Execute(Dictionary<string, string> parameters);
        IEnumerable<JToken> Execute(string fieldsToMap, string webApiUrl);

        void ReadConfig();

        void AccessSource();

        void ReadSource();

        void TransformSourceData();

        void ValidateSourceData(Dictionary<string, string> fieldsToMap);

    }
}
