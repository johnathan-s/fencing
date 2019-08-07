using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class ParseTournamentCompetitorsTests : TestBase
    {
        private ParseTournamentCompetitors parseTournamentCompetitors;

        public ParseTournamentCompetitorsTests()
        {
            this.parseTournamentCompetitors = new ParseTournamentCompetitors(base.filepath);
        }
 
        [TestMethod]
        public void getTournamentCompetitorsTest1()
        {
            List<TournamentCompetitors> tournamentCompetitors = this.parseTournamentCompetitors.getTournamentCompetitors();

            Assert.IsNotNull(tournamentCompetitors);
            Assert.IsTrue(tournamentCompetitors.Count > 0);

            foreach (TournamentCompetitors tournamentCompetitor in tournamentCompetitors)
            {
                Assert.IsFalse(String.IsNullOrEmpty(tournamentCompetitor.Nom));
                Assert.IsFalse(String.IsNullOrEmpty(tournamentCompetitor.Prenom));
                Console.WriteLine(tournamentCompetitor.Nom + " " + tournamentCompetitor.Prenom);
            }
        }
    }
}
