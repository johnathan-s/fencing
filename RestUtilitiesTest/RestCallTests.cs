using Autofac;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestUtilities;
using System;
using System.Diagnostics;

namespace RestUtilitiesTest
{
    [TestClass]
    public class RestCallTests
    {
 
        [TestMethod]
        public void doGet_FromElasticsearch_Test()
        {
            string testUrl = "http://localhost:9200/_cat/indices?v";

            using ( var mock = AutoMock.GetLoose())
            {
                Autofac.Core.Parameter param = new NamedParameter("url", testUrl);

                mock.Mock<IRestCall>()
                    .Setup(x => x.DoGet())
                    .Returns("");

                var cls = mock.Create<RestCall>(param);

                var actual = cls.DoGet();

                Debug.WriteLine("output: " + actual);

                Assert.IsNotNull(actual);
            }
        }

        [TestMethod]
        public void doPost_FromElasticsearch_Test()
        {
            string testUrl = "http://localhost:9200/_cat/indices?v";
            string rawJson = "{ \"foo\" : \"bar\"}";

            using (var mock = AutoMock.GetLoose())
            {
                Autofac.Core.Parameter param = new NamedParameter("url", testUrl);

                mock.Mock<IRestCall>()
                    .Setup(x => x.DoPost(rawJson))
                    .Returns<string>(x => x);

                var cls = mock.Create<RestCall>(param);

                var actual = cls.DoPost(rawJson);

                Debug.WriteLine("output: " + actual);

                Assert.IsNotNull(actual);
            }
        }
    }
}
