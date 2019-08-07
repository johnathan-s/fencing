using FencingDataModels;
using FencingResultsIntoElasticsearch;
using HtmlAgilityPack;
using HtmlPageParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FencingResultsIntoElasticsearchTest
{
    [TestClass]
    public class TransformRankingResultsIntegrationTests
    {

        private ParsePage parsePage = new ParsePage();
        private TransformRankingResults transformRankingResults = new TransformRankingResults();
        private string testUrl = "https://fencing.nz/rankings.php?weapon=Foil&sex=Mens&cat=open&submit=Get+Ranking";
        private string tableXPath = "//td[@class='centerboxtext']/table";
        private string weapon = "Foil";
        private string sex = "Mens";
        private string category = "open";

        [TestMethod]
        public void getHtmlDocument_SerializeToRankingObject_ValidateRankingObject_IntegregationTest1()
        {
            HtmlDocument htmlDoc = this.parsePage.getHtmlDocument(testUrl);

            List<List<KeyValuePair<string, string>>> serializedTable = this.parsePage.getTable(htmlDoc, tableXPath);

            List<RankingModel> rankingModelList = transformRankingResults.getRankingsSerialize(weapon, sex, category);

            foreach (RankingModel ranking in rankingModelList)
            {
                Assert.IsNotNull(ranking);

                string json = transformRankingResults.serializeRankingModel(ranking);
                Assert.IsFalse(String.IsNullOrEmpty(json));
                Console.WriteLine(json);
            }
        }


    }
}
