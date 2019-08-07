using FencingResultsIntoElasticsearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FencingResultsIntoElasticsearchTest
{
    [TestClass]
    public class ElasticsearchUrlHelperTests
    {
        private ElasticsearchUrlHelper elasticsearchUrlHelper = new ElasticsearchUrlHelper("twitter");

        [TestMethod]
        public void getElasticsearchUrlTest1()
        {
            Console.WriteLine(elasticsearchUrlHelper.getElasticsearchUrl());

            Assert.IsTrue(elasticsearchUrlHelper.getElasticsearchUrl().StartsWith("http://localhost:9200/twitter/_doc/"));
        }
    }
}
