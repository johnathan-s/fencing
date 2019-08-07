using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestUtilities;
using System;

namespace RestUtilitiesTest
{
    [TestClass]
    public class RestCallTests
    {
        private RestCall restCall = new RestCall();

        [TestMethod]
        public void doGet_FromElasticsearch_Test()
        {
            string testUrl = "http://localhost:9200/_cat/indices?v";
            string result = this.restCall.doGet(testUrl);
            Console.WriteLine(result);
            Assert.IsFalse(String.IsNullOrEmpty(result), "This will fail if the elasticsearch instance or kibana instance is not up.");
        }
    }
}
