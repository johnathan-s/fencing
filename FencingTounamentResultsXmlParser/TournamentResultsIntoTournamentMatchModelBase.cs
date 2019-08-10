using System;
using System.Collections.Generic;
using FencingDataModels;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FencingTournamentResultsXmlParser
{
    /// <summary>
    /// This class will pull all bout information from the other casses and put into a model ready for database insersion.
    /// </summary>
    public class TournamentResultsIntoTournamentMatchModelBase
    {
        private string filePath;
        public List<TournamentCompetitors> tournamentCompetitors;

        public TournamentResultsIntoTournamentMatchModelBase(string filepath)
        {
            setFilePath(filepath);
            this.tournamentCompetitors = getTournamentCompetitors();
        }

   
        internal CompetitionIndividuelle getCompetitionIndividuelle()
        {
            ParseCompetitionInformation parseCompetitionInformation = new ParseCompetitionInformation(getFilePath());
            return parseCompetitionInformation.getCompetitionIndividuelle();
        }

        internal List<SuiteDeTableaux> getSuiteDeTableauxMatches()
        {
            ParseTableauMatches parseTableauMatches = new ParseTableauMatches(getFilePath());
            return parseTableauMatches.getSuiteDeTableauxMatches();
        }

        internal List<TournamentCompetitors> getTournamentCompetitors()
        {
            ParseTournamentCompetitors parseTournamentCompetitors = new ParseTournamentCompetitors(getFilePath());
            return parseTournamentCompetitors.getTournamentCompetitors();
        }
  

        internal List<Poule> getPouleMatches()
        {
            ParsePouleMatches parsePouleMatches = new ParsePouleMatches(getFilePath());
            return parsePouleMatches.getPouleMatches();
        }

        internal void setFilePath(string filepath)
        {
            this.filePath = filepath;
        }

        internal string getFilePath()
        {
            return this.filePath;
        }

        public DateTime getDateTimeFromXmlFormat(string date)
        {
            return DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public string serializeTournamentMatchModel(TournamentMatchModel tournamentMatchModel)
        {
            var stream1 = new MemoryStream();

            var ser = new DataContractJsonSerializer(typeof(TournamentMatchModel));

            ser.WriteObject(stream1, tournamentMatchModel);

            stream1.Position = 0;

            var sr = new StreamReader(stream1);

            string serializedResult = sr.ReadToEnd();

            sr.Close();

            sr.Dispose();

            return serializedResult;
        }

        public TournamentCompetitors getCompetitor(string ID)
        {
            var r = this.tournamentCompetitors.Find(p => p.ID == ID);
            return r;
        }
    }
}
