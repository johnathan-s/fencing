using HtmlAgilityPack;
using HtmlPageParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HtmlPageParserTest
{
    [TestClass]
    public class ParsePageTests
    {

        private ParsePage parsePage = new ParsePage();
        private string testUrl = "http://www.fencingmidsouth.org.nz/Competitions/Presidents%20Cup/2019/Results/FTEvent1.htm";

        [TestMethod]
        public void getHtmlDocumentTest1()
        {
            string testUrl = "http://www.fencingmidsouth.org.nz/Competitions/Presidents%20Cup/2019/Results/FTEvent1.htm";
            HtmlDocument htmlDoc = this.parsePage.getHtmlDocument(testUrl);
            var content = htmlDoc.DocumentNode.SelectSingleNode("//body");
            Console.WriteLine(content.InnerText);
            Assert.IsNotNull(htmlDoc);
            Assert.IsNotNull(htmlDoc.DocumentNode);
        }

        [TestMethod]
        public void getTableTest1()
        {
            HtmlDocument htmlDoc = this.parsePage.getHtmlDocument(testUrl);
            List<List<KeyValuePair<string, string>>> searializedTable = this.parsePage.getTable(htmlDoc, "//table[@class='dataTable']");
            foreach (List<KeyValuePair<string, string>> tablerow in searializedTable)
            {
                foreach (KeyValuePair<string, string> row in tablerow)
                {
                    Console.Write("key: " + row.Key + " value: " + row.Value + " ");
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void getTableTest2()
        {
            string url = "https://fencing.nz/rankings.php?weapon=Foil&sex=Mens&cat=open&submit=Get+Ranking";
            HtmlDocument htmlDoc = this.parsePage.getHtmlDocument(url);
            List<List<KeyValuePair<string, string>>> searializedTable = this.parsePage.getTable(htmlDoc, "//td[@class='centerboxtext']/table");
            foreach (List<KeyValuePair<string, string>> tablerow in searializedTable)
            {
                foreach (KeyValuePair<string, string> row in tablerow)
                {
                    Console.Write("key: " + row.Key + " value: " + row.Value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
