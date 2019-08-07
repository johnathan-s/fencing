using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class ParseCompetitionInformationTests : TestBase
    {
        private ParseCompetitionInformation parseCompetitionInformation;

        public ParseCompetitionInformationTests()
        {
            this.parseCompetitionInformation = new ParseCompetitionInformation(base.filepath);
        }

        [TestMethod]
        public void getCompetitionIndividuelleTest1()
        {
            CompetitionIndividuelle competitionIndividuelle = this.parseCompetitionInformation.getCompetitionIndividuelle();
            Assert.IsFalse(String.IsNullOrEmpty(competitionIndividuelle.TitreLong));
        }
    }
}
