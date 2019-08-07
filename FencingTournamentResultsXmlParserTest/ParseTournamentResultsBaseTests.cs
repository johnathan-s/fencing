using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class ParseTournamentResultsBaseTests : TestBase
    {
        private ParseTournamentResultsBase parseTournamentResultsBase;
        

        public ParseTournamentResultsBaseTests()
        {
            this.parseTournamentResultsBase = new ParseTournamentResultsBase(filepath);
        }

        [TestMethod]
        public void parseTournamentResultsTestsTest1()
        {
            Assert.IsNotNull(parseTournamentResultsBase.xdoc);
        }

  
    }
}
