using System;

using NUnit.Framework;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Implementation;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviderTests
{
    [TestFixture]
    public class DataProviderTest
    {
        private WebApiDataProvider _dataProvider;

        [SetUp]
        public void Init()
        {
            _dataProvider = new WebApiDataProvider("http://services.realestate.com.au/services/listings/sold/in-Mandurah,WA%206210/with-market-category/house");
        }

        [Test]
        [TestCase("$.results.[*].address.location.[latitude,longitude]", "http://services.realestate.com.au/services/listings/sold/in-Mandurah,WA%206210/with-market-category/house")]
        public void CanExecute(string jsonPath, string webApUrl)
        {
            // Arrange
            var dict = new Dictionary<string, string>();
            dict.Add("$.results.[*].title", "Title");
            dict.Add("$.results.[*].address.location.latitude", "Latitude");
            dict.Add("$.results.[*].address.location.longitude", "Longitude");

            // Act
            var x = _dataProvider.Execute(dict, webApUrl);

            // Assert
            Assert.IsNotNull(x);
        }
    }
}
