using System;

using NUnit.Framework;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Interfaces;
using Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Implementation;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviderTests
{
    [TestFixture]
    public class DataProviderTest
    {
        private WebApiDataProvider _dataProvider;

        [SetUp]
        public void Init()
        {
            _dataProvider = new WebApiDataProvider();
        }

        [Test]
        [TestCase("http://services.realestate.com.au/services/listings/sold/in-Mandurah,WA%206210/with-market-category/house")]
        public void CanMakeRequest(string requestUrl)
        {
            // Arrange

            // Act
            var response = WebApiDataProvider.MakeRequest(requestUrl);

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
