using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class ParseTableauMatchesTests : TestBase
    {
        private ParseTableauMatches parseTableauMatches;

        public ParseTableauMatchesTests()
        {
            this.parseTableauMatches = new ParseTableauMatches(base.filepath);
        }

        [TestMethod]
        public void getSuiteDeTableauxTest()
        {
            IEnumerable<XElement> xSuiteDeTableaux = parseTableauMatches.getSuiteDeTableaux();
            Assert.IsNotNull(xSuiteDeTableaux);
            Assert.IsTrue(xSuiteDeTableaux.ToArray().Length > 0);
        }

        [TestMethod]
        public void getTableausTest()
        {
            IEnumerable<XElement> xSuiteDeTableaux = parseTableauMatches.getSuiteDeTableaux();
            XElement xEl = xSuiteDeTableaux.First();
            Assert.IsNotNull(xEl);

            IEnumerable<XElement> xTableaus = parseTableauMatches.getTableaus(xEl);
            Assert.IsNotNull(xTableaus);
            Assert.IsTrue(xTableaus.ToArray().Length > 0);
        }

        [TestMethod]
        public void getMatchesTest()
        {
            IEnumerable<XElement> xSuiteDeTableaux = parseTableauMatches.getSuiteDeTableaux();
            XElement xEl = xSuiteDeTableaux.First();
            Assert.IsNotNull(xEl);

            IEnumerable<XElement> xTableaus = parseTableauMatches.getTableaus(xEl);
            Assert.IsNotNull(xTableaus);
            Assert.IsTrue(xTableaus.ToArray().Length > 0);

            IEnumerable<XElement> xMatches = parseTableauMatches.getMatches(xTableaus.First());
            Assert.IsNotNull(xMatches);
            Assert.IsTrue(xMatches.ToArray().Length > 0);
        }

        [TestMethod]
        public void getMatchResultsTest()
        {
            IEnumerable<XElement> xSuiteDeTableaux = parseTableauMatches.getSuiteDeTableaux();
            XElement xEl = xSuiteDeTableaux.First();
            Assert.IsNotNull(xEl);

            IEnumerable<XElement> xTableaus = parseTableauMatches.getTableaus(xEl);
            Assert.IsNotNull(xTableaus);
            Assert.IsTrue(xTableaus.ToArray().Length > 0);

            IEnumerable<XElement> xMatches = parseTableauMatches.getMatches(xTableaus.First());
            Assert.IsNotNull(xMatches);
            Assert.IsTrue(xMatches.ToArray().Length > 0);

            IEnumerable<XElement> xMatchResults = parseTableauMatches.getMatchResults(xMatches.First());
            Assert.IsNotNull(xMatchResults);
            Assert.IsTrue(xMatchResults.ToArray().Length == 2);// one result for the fencer who won and one for the fencer that lost.
        }

        [TestMethod]
        public void getSuiteDeTableauxMatchesTest()
        {
            List<SuiteDeTableaux> suiteDeTableauxes = parseTableauMatches.getSuiteDeTableauxMatches();
            Assert.IsNotNull(suiteDeTableauxes);
            Assert.IsTrue(suiteDeTableauxes.ToArray().Length > 0);
            

            SuiteDeTableaux suiteDeTableaux = suiteDeTableauxes.First();
            Assert.IsTrue(suiteDeTableaux.tableaus.Count > 0);
            Tableau tableau = suiteDeTableaux.tableaus.First();
            Assert.IsNotNull(tableau);
            Assert.IsTrue(tableau.matches.Count > 0);

            Match match = tableau.matches.First();
            Assert.IsNotNull(match);
            Assert.IsTrue(match.matchResults.Count == 2);

        }
    }
}
