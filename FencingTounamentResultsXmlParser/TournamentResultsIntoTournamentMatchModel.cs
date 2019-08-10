using System;
using System.Collections.Generic;
using FencingDataModels;

namespace FencingTournamentResultsXmlParser
{
    /// <summary>
    /// This class will pull all bout information from the other casses and put into a model ready for database insersion.
    /// </summary>
    public class TournamentResultsIntoTournamentMatchModel : TournamentResultsIntoTournamentMatchModelBase
    {
        public TournamentResultsIntoTournamentMatchModel(string filepath) : base(filepath)
        {
            
        }

        public List<TournamentMatchModel> getTournamentMatcheModels()
        {
            List<TournamentMatchModel> tournamentMatches = new List<TournamentMatchModel>();

            CompetitionIndividuelle competitionIndividuelle = getCompetitionIndividuelle();
            DateTime competitionDate = getDateTimeFromXmlFormat(competitionIndividuelle.Date);
            string competitonName = competitionIndividuelle.TitreLong;

            tournamentMatches.AddRange(getTournamentPouleMatchModels(competitonName, competitionDate));

            tournamentMatches.AddRange(getTournamentTableauMatchModels(competitonName, competitionDate));

            return tournamentMatches;
        }

        public List<TournamentMatchModel> getTournamentPouleMatchModels(string competitonName, DateTime competitionDate)
        {
            List<TournamentMatchModel> tournamentPouleMatchModels = new List<TournamentMatchModel>();

            foreach(Poule poule in getPouleMatches())
            {
                tournamentPouleMatchModels.AddRange(tournamentModelHelper(competitonName, competitionDate, 
                    "Poule " + poule.ID, "Poule", poule.pouleMatches));
            }
            return tournamentPouleMatchModels;
        }

        public List<TournamentMatchModel> getTournamentTableauMatchModels(string competitonName, DateTime competitionDate)
        {
            List<TournamentMatchModel> tournamentPouleMatchModels = new List<TournamentMatchModel>();

            SuiteDeTableaux suiteDeTableaux = getSuiteDeTableauxMatches()[0];

            foreach (Tableau tableau in suiteDeTableaux.tableaus)
            {
                tournamentPouleMatchModels.AddRange(tournamentModelHelper(competitonName, competitionDate, tableau.Titre,
                    "Tableau", tableau.matches));
            }
            return tournamentPouleMatchModels;
        }

        public List<TournamentMatchModel> tournamentModelHelper(string tournamentName, DateTime tournamentDate, string matchTitle, 
            string matchType, List<Match> matches)
        {
            List<TournamentMatchModel> tournamentPouleMatchModels = new List<TournamentMatchModel>();
 
            foreach (Match match in matches)
            {
                TournamentMatchModel tournamentMatchModel = new TournamentMatchModel();

                tournamentMatchModel.TournamentName = tournamentName;
                tournamentMatchModel.TournamentDate = tournamentDate;
                tournamentMatchModel.matchId = match.ID;
                tournamentMatchModel.matchTitle = matchTitle;
                tournamentMatchModel.matchType = matchType;

                MatchResult rightMatchResults = match.matchResults[0];
                TournamentCompetitors rightCompetitor = getCompetitor(rightMatchResults.REF);
                tournamentMatchModel.rightProname = rightCompetitor.Prenom;
                tournamentMatchModel.rightSurname = rightCompetitor.Nom;
                tournamentMatchModel.rightScore = int.Parse(rightMatchResults.Score);
                tournamentMatchModel.rightStatus = rightMatchResults.Statut;

                MatchResult leftMatchResults = match.matchResults[1];
                TournamentCompetitors leftCompetitor = getCompetitor(leftMatchResults.REF);
                tournamentMatchModel.leftProname = leftCompetitor.Prenom;
                tournamentMatchModel.leftSurname = leftCompetitor.Nom;
                tournamentMatchModel.leftScore = int.Parse(leftMatchResults.Score);
                tournamentMatchModel.leftStatus = leftMatchResults.Statut;

                tournamentPouleMatchModels.Add(tournamentMatchModel);
            }
            return tournamentPouleMatchModels;
        }
       
    }

   
}
