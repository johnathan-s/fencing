using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class ParsePouleMatchesTests : TestBase
    {
        private ParsePouleMatches parsePouleMatches;

        public ParsePouleMatchesTests()
        {
            this.parsePouleMatches = new ParsePouleMatches(base.filepath);
        }

        [TestMethod]
        public void getPoulesTest()
        {
            IEnumerable<XElement> xPoules = parsePouleMatches.getPoules();
            Assert.IsNotNull(xPoules);
            Assert.IsTrue(xPoules.ToArray().Length > 0);
        }

        [TestMethod]
        public void getMatchesTest()
        {
            IEnumerable<XElement> xPoules = parsePouleMatches.getPoules();
            XElement xEl = xPoules.First();
            IEnumerable<XElement> xMatches = parsePouleMatches.getMatches(xEl);
            Assert.IsNotNull(xMatches);
            Assert.IsTrue(xMatches.ToArray().Length > 0);
        }

        [TestMethod]
        public void getPouleMatchesTest1()
        {
            List<Poule> poules = parsePouleMatches.getPouleMatches();
            Assert.IsNotNull(poules);
            Assert.IsTrue(poules.Count > 0);
        }
    }
}
