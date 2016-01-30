using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Diversus.Hackathon2016.Foundation.OpenDataAgent
{
    public static class Templates
    {
        public static class DataPoint
        {
            public static readonly ID ID = new ID("{C6C4A1CD-2F2B-46D6-8558-15C644667057}");
            public static readonly ID Title = new ID("{C116F31A-D6ED-49B1-BFA7-318FA08D2A80}");
            public static readonly ID Points = new ID("{4C65C83A-CC38-4AAB-B6F6-D7D9730D9435}");
            public static readonly ID Value = new ID("{0C10A605-0AF2-4E95-B7BE-ED3375B644B3}");
            public static readonly ID Type = new ID("{F2586C13-3CDE-4F9A-B79E-E9B1BB3A0E7B}");

        }
        public static class DataSet
        {
            public static readonly ID ID = new ID("{D186CB79-1252-43B4-B3CD-32FDE3B38243}");
            public static readonly ID Color = new ID("{DBD2F98F-02FE-4050-9B14-EA14F01C6975}");
            public static readonly ID AggregationProvider = new ID("{019D5F98-85B0-4750-9B0A-87B3233F21D4}");
            public static readonly ID ProviderConfig = new ID("{4E938E7E-C1A2-4467-AFDB-DF2059182C8F}");
            public static readonly ID FacetName = new ID("{A01978B6-540C-46D3-9B33-AC414BC7A615}");
        }
        public static class Repository
        {
            public static readonly ID ID = new ID("{44F0C94F-8090-4E1B-BE69-5556951F0CB4}");
            public static readonly ID Longitude = new ID("{FEAE8E4F-993E-4A55-BF60-8FB3196CA122}");
            public static readonly ID Lattitude = new ID("{AC640109-42D5-40E4-9D07-329B8DE1313F}");
            public static readonly ID Zoom = new ID("{B7C7F116-D94C-4C31-B251-4BFE8F0DC5F1}");
        }
    }
}