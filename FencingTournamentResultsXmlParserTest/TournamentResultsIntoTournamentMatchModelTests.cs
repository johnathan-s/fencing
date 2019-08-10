using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingDataModels;
using System.Collections.Generic;

namespace FencingTournamentResultsXmlParser
{
    [TestClass]
    public class TournamentResultsIntoTournamentMatchModelTests : TestBase
    {
        private TournamentResultsIntoTournamentMatchModel tournamentResultsIntoTournamentMatchModel;

        public TournamentResultsIntoTournamentMatchModelTests()
        {
            this.tournamentResultsIntoTournamentMatchModel = new TournamentResultsIntoTournamentMatchModel(base.filepath);
        }
        [TestMethod]
        public void getDateTimeFromXmlFormatTest1()
        {
            string testDate = "14.07.2019";
            DateTime d = tournamentResultsIntoTournamentMatchModel.getDateTimeFromXmlFormat(testDate);
            DateTime dt = new DateTime(2019, 07, 14);
            Assert.IsTrue(d.Equals(dt));
        }

        [TestMethod]
        public void getCompetitorTest1()
        {
            string ID = "-10";
            TournamentCompetitors tournamentCompetitors = tournamentResultsIntoTournamentMatchModel.getCompetitor(ID);
            Assert.IsNotNull(tournamentCompetitors);
            Console.WriteLine(tournamentCompetitors.Nom +  " " + tournamentCompetitors.Prenom);
        }

        [TestMethod]
        public void getCompetitorTest2()
        {
            string ID = "-27";
            TournamentCompetitors tournamentCompetitors = tournamentResultsIntoTournamentMatchModel.getCompetitor(ID);
            Assert.IsNotNull(tournamentCompetitors);
            Console.WriteLine(tournamentCompetitors.Nom + " " + tournamentCompetitors.Prenom);
        }

        [TestMethod]
        public void getTournamentMatcheModelsTest()
        {
            List<TournamentMatchModel> tournamentMatchModels = tournamentResultsIntoTournamentMatchModel.getTournamentMatcheModels();
            Assert.IsNotNull(tournamentMatchModels);
            Assert.IsTrue(tournamentMatchModels.Count > 0);
        }

        [TestMethod]
        public void serializeTournamentMatchModelTest1()
        {
            List<TournamentMatchModel> tournamentMatchModels = tournamentResultsIntoTournamentMatchModel.getTournamentMatcheModels();
            string json = tournamentResultsIntoTournamentMatchModel.serializeTournamentMatchModel(tournamentMatchModels[0]);
            Assert.IsFalse(String.IsNullOrEmpty(json));
            Console.WriteLine(json);
        }

        [TestMethod]
        public void serializeTournamentMatchModelTest2()
        {
            List<TournamentMatchModel> tournamentMatchModels = tournamentResultsIntoTournamentMatchModel.getTournamentMatcheModels();
            string json = tournamentResultsIntoTournamentMatchModel.serializeTournamentMatchModel(tournamentMatchModels[tournamentMatchModels.Count -2]);
            Assert.IsFalse(String.IsNullOrEmpty(json));
            Console.WriteLine(json);
        }
    }
}
