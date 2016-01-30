using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces
{
    public interface IDataProvider
    {
        void Execute();

        void ReadConfig();

        void AccessSource();

        void ReadSource();

        void TransformSourceData();

        void ValidateSourceData();

    }
}
